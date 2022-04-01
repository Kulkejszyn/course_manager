import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {CourseModel} from "./courseModel";
import { environment } from 'src/environments/environment';


@Injectable({
	providedIn: 'root'
})
export class CoursesService {

	constructor(private http: HttpClient) {
	}

	public createCourse(model: CourseModel): Observable<Object> {
		return this.http.post(`${environment.apiUrl}/Courses/CreateOrUpdate`, model)
	}

	public deleteCourse(courseId: number): Observable<Object> {
		return this.http.delete(`${environment.apiUrl}/Courses/${courseId}`)
	}

	public getCourses(): Observable<CourseModel[]> {
		return this.http.get<CourseModel[]>(`${environment.apiUrl}/Courses`)
	}

	public getCourseById(courseId: number): Observable<Object> {
		return this.http.get<CourseModel>(`${environment.apiUrl}/Courses/${courseId}`)
	}
}
