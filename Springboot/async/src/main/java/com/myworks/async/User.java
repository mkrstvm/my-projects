package com.myworks.async;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.xml.crypto.dsig.spec.XSLTTransformParameterSpec;

@JsonIgnoreProperties(ignoreUnknown = true)
public class User {

    private   String Name;
    private   String blog;

    public String getName(){
        return  Name;
    }
    public String getBlog(){
        return  blog;
    }

    public  void setName(String value){
        Name = value;
    }

    public  void setBlog(String value){
        blog = value;
    }

    @Override
    public String toString()
    {
        return "Name =" + Name + " Blog = " + blog;
    }
}
