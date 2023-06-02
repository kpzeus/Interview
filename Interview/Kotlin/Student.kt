package com.codility

class University(private val repository: Repository<Student>) {
    fun getPaidCoursesWithTheNumbersOfSubscribedStudents(coursesCount: Int): Map<Course, Int>
           {
                var students = repository.get();

                val map = HashMap<Course,Int>();

                for (student in students) {                    
                    for (course in student.subscribedCourses) {
                        if(course.isPaid){
                            map.put(course, map.getOrDefault(course, 0)+1);
                        }      
                    }         
                }

                val result = 
                map.toList().sortedBy{(_, value) -> value}.reversed().take(coursesCount).toMap()

                return result;
           }
}       
