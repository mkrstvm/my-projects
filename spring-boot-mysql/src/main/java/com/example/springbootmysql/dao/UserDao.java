package com.example.springbootmysql.dao;

import com.example.springbootmysql.model.USER;
import org.springframework.data.repository.CrudRepository;

public interface UserDao extends CrudRepository<USER, Integer> {
}
