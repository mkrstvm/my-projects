import * as express from "express";
import { Application } from "express";
import { getAllCourses } from "./get-courses-route";
import { getCourseById } from "./get-courses-route";
import { loginUser } from "./login-route";

const app: Application = express();
const cors = require('cors');
app.use(cors({origin:true}));

app.route('/api/courses').get(getAllCourses);

app.route('/api/courses/:id').get(getCourseById);

// app.route('/api/lessons').get(searchLessons);

// app.route('/api/courses/:id').put(saveCourse);

app.route('/api/login').post(loginUser);

const httpServer = app.listen(9000,() => 
{
    console.log("HTTP REST API server running at http://localhost:9000" );
});
