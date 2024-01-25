package com.example.springbootmysql;

import com.example.springbootmysql.controller.UserController;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@ComponentScan(basePackageClasses = UserController.class)
public class SpringMySQlApplication {
    public static void main(String[] args)
    {
        SpringApplication.run(SpringMySQlApplication.class,args);
    }
}
