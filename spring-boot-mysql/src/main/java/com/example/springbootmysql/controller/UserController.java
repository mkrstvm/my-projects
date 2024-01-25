package com.example.springbootmysql.controller;

import com.example.springbootmysql.dao.UserDao;
import com.example.springbootmysql.model.USER;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/user")
public class UserController {
    @Autowired
    private UserDao dao;

    @PostMapping("/addusers")
    public String AddUsers(@RequestBody List<USER> users) {
        dao.saveAll(users);
        return "user added : " + users.size();
    }

    @PostMapping("/adduser")
    public String AddUser(@RequestBody USER user) {
        dao.save(user);
        return "user added : " + user.toString();
    }

    @GetMapping("/getusers")
    public List<USER> getUsers() {
        return (List<USER>) dao.findAll();
    }

}