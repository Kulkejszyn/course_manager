import {TopicModel} from "../services/topicModel";

export interface CourseModel {
	courseId?: number;
	name: string;
	description: string;
	topics: TopicModel[];
}
