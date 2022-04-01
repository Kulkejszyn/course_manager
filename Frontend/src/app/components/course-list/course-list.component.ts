import {Component, OnInit} from '@angular/core';
import {CoursesService} from "../../models/courses.service";
import {CourseModel} from "../../models/courseModel";
import {MatDialog} from "@angular/material/dialog";
import {CourseWizardComponent} from "../modals/course-wizard/course-wizard.component";
import {PopupComponent} from "../modals/popup/popup.component";

@Component({
	selector: 'app-course-list',
	templateUrl: './course-list.component.html',
	styleUrls: ['./course-list.component.less']
})
export class CourseListComponent implements OnInit {
	public courses: CourseModel[];

	constructor(private coursesService: CoursesService, private dialog: MatDialog) {
	}

	ngOnInit(): void {
		this.getCourses();
	}

	public createOrEditCourse(event: MouseEvent, course?: CourseModel): void {
		event.stopPropagation();
		let wizardDialog = this.dialog.open(CourseWizardComponent, {
			data: course
		});
		wizardDialog.afterClosed().subscribe(res => {
			if (res) {
				this.getCourses();
			}
		});
	}

	public deleteCourse(event: MouseEvent, course: CourseModel) {
		event.stopPropagation();
		if (!course.courseId) return;

		const popup = this.dialog.open(PopupComponent, {
			data: "Czy na pewno chcesz usunąć Kurs?"
		});
		popup.afterClosed().subscribe(res => {
			if (res) {
				this.coursesService.deleteCourse(course.courseId!).subscribe(() => {
					this.getCourses();
				})
			}
		});
	}

	private getCourses() {
		this.coursesService.getCourses().subscribe(res => {
			this.courses = res;
			//tutaj mozna dodac jakis spinner
		})
	}
}
