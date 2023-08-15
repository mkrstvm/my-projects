
import { Request,Response } from "express";
import { COURSES } from "./db-data";

export function getAllCourses(req:Request, res:Response)
{
    setTimeout(() =>{
        res.status(200).json({payload : Object.values(COURSES)});
    }, 1500)
    
}

export function getCourseById(req:Request, res:Response)
{
    const courseId = req.params["id"];
    const courses:any = Object.values(COURSES);
    const course = courses.find((course: { id: string; }) => course.id == courseId);
    return res.status(200).json(course);
}