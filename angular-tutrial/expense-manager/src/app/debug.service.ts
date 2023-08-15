import { Injectable } from '@angular/core';

export class DebugService {

  constructor() { }

  info(message : string) : void{
    console.log(message);
  }
}
