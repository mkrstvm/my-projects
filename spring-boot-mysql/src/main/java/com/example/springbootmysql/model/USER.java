package com.example.springbootmysql.model;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.*;

@Entity
@Table(name = "USER")
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@ToString
public class USER {
    @Id
    @GeneratedValue
    private int ID;
    private String FIRST_NAME;
    private String LAST_NAME;
    private String EMAIL;
    private String PASSWORD;

}