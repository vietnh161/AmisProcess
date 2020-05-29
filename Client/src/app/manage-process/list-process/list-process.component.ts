import { Component, OnInit } from '@angular/core';
import {listProcessData} from '../../data/list-process'

@Component({
  selector: 'app-list-process',
  templateUrl: './list-process.component.html',
  styleUrls: ['./list-process.component.css'],
})
export class ListProcessComponent implements OnInit {

  data = listProcessData;

  constructor() { }

  ngOnInit(): void {
  }

}
