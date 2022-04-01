import {ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {CoursesService} from "../../../models/courses.service";
import {CourseModel} from "../../../models/courseModel";
import {TopicModel} from "../../../services/topicModel";

@Component({
	selector: 'app-course-wizard',
	templateUrl: './course-wizard.component.html',
	styleUrls: ['./course-wizard.component.less'],
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class CourseWizardComponent implements OnInit {

	public courseForm: FormGroup;
	public topicForm: FormGroup;

	constructor(private cdr: ChangeDetectorRef,
				private coursesService: CoursesService,
				public dialog: MatDialogRef<CourseWizardComponent>,
				@Inject(MAT_DIALOG_DATA) public course: CourseModel) {
	}


	ngOnInit(): void {
		this.course = this.course ?? {
			name: '',
			description: '',
			topics: []
		};

		this.courseForm = new FormGroup({
			name: new FormControl(this.course.name, [Validators.required, Validators.maxLength(40)],),
			description: new FormControl(this.course.description, [Validators.required]),
		});

		this.topicForm = new FormGroup({
			topic: new FormControl('', [Validators.required, Validators.maxLength(40)],),
			topicNumber: new FormControl('', [Validators.required, Validators.min(0)]),
		});
	}

	public addTopic() {
		this.topicForm.markAllAsTouched()
		if (!this.topicForm.valid) return;
		this.course.topics.push({
				topicNumber: this.topicForm.controls['topicNumber'].value,
				topic: this.topicForm.controls['topic'].value
			}
		)
		this.course.topics = this.course.topics.sort((t1, t2) => t1.topicNumber - t2.topicNumber);
		this.topicForm.reset()
	}

	public saveCourse() {
		this.courseForm.markAllAsTouched()
		if (!this.courseForm.valid) return;
		this.coursesService.createCourse({
			name: this.courseForm.controls['name'].value,
			topics: this.course.topics,
			description: this.courseForm.controls['description'].value,
			courseId: this.course.courseId
		}).subscribe(() => {
			this.dialog.close(true)
		});
	}

	public removeTopic(topic: TopicModel) {
		this.course.topics = this.course.topics.filter(courseTopic => courseTopic !== topic);
	}
}
