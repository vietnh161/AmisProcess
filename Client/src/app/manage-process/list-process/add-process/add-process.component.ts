import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/_services';
import { listProcessData } from 'src/app/data/list-process';
import { categoryData } from 'src/app/data/category';
import { phaseData } from 'src/app/data/phase';
import { Process } from 'src/app/_models';



@Component({
    selector: 'app-add-process',
    templateUrl: './add-process.component.html',
    styleUrls: ['./add-process.component.css'],
})

export class AddProcessComponent implements OnInit {

    //@Input('')

    currentUser;
    listProcess;
    listCategory;
    newProcess = {
        name: '',
        description: '',
        categoryId: null,
    };
    newCategory = '';

    canAddCategory = false;
    errorMessage: string;


    constructor(private route: ActivatedRoute, private authenticationService: AuthenticationService, private router: Router) {

        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
        this.listProcess = listProcessData;
        this.listCategory = categoryData;
    }

    ngOnInit(): void {
    }

    addProcessHandle() {
        //   console.log(this.newCategory);

        if (this.newProcess.name == '' || this.newProcess.description == '') {
            this.errorMessage = "Tên quy trình hoặc mô tả không được để trống";
            return;
        } else {
            if (this.newProcess.categoryId == null || this.canAddCategory) {
                if (this.newCategory == '') {
                    this.errorMessage = "Danh mục không được để trống"
                    return;
                } else {
                    this.newProcess.categoryId == null

                    var newCtg = {
                        id: 1 + this.listCategory.map(x => x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
                        name: this.newCategory
                    }
                    this.listCategory.push(newCtg);
                    this.newProcess.categoryId = newCtg.id;
                    console.log(this.newProcess);
                }
            }
        }
        var item:Process = {
            id: 1 + this.listProcess.map(x => x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
            name: this.newProcess.name,
            description: ' ',
            createdBy: this.currentUser.firstName + ' ' + this.currentUser.lastName,
            createdTime: new Date().toISOString(),
            updatedTime: new Date().toISOString(),
            updatedBy: this.currentUser.firstName + ' ' + this.currentUser.lastName,
            status: 'maintain',
            categoryId: this.newProcess.categoryId,
            category: this.listCategory.find(x => x.id == this.newProcess.categoryId)
        }

        this.listProcess.push(item);


        var newPhase = [
            {
                id: 1 + phaseData.map(x => x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
                serial: 1,
                name: 'Khởi tạo',
                description: '',
                canDel: false,
                isLastPhase: false,
                timeImplementType: '',
                timeImplement: null,
                personImplementType: 'all',
                personImplement: [],
                fields: [],
                processId: item.id,
                process: item
            },
            {
                id: 2 + phaseData.map(x => x.id).reduce((accumulator, currentValue) => Math.max(accumulator, currentValue)),
                serial: 2,
                name: 'Hoàn thành',
                description: '',
                timeImplementType: '',
                canDel: false,
                isLastPhase: true,
                timeImplement: null,
                personImplementType: 'all',
                personImplement: [],
                fields: [],
                processId: item.id,
                process: item
            },
        ]
        phaseData.push(newPhase[0])
        phaseData.push(newPhase[1])


        this.router.navigateByUrl("manage-process/process/" + item.id)

    }
}