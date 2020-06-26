import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services';
import { Process } from 'src/app/models';
import { CategoryService } from 'src/app/services/category.service';
import { ProcessService } from 'src/app/services/process.service';


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
    newProcess;

    errorMessage: string;


    constructor(private route: ActivatedRoute,
        private authenticationService: AuthenticationService,
        private router: Router,
        private categoryService: CategoryService,
        private processService: ProcessService,
    ) {

        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

        this.newProcess = {
            name: '',
            description: '',
            category: {
                createdBy: '',
                name: ''
            },
        };

    }

    ngOnInit(): void {
        this.categoryService.getAll()
            .subscribe(
                result => {
                    this.listCategory = result;
                },
                error => {
                    console.log(error);

                }
            )
    }

    addProcessHandle() {


        if (this.newProcess.name == '' || this.newProcess.description == '') {
            this.errorMessage = "Tên quy trình hoặc mô tả không được để trống";
            return;
        } else {
            if (this.newProcess.category.name == '') {
                this.errorMessage = "Danh mục không được để trống"
                return;
            } else {

                this.processService.addProcess(this.newProcess)
                    .subscribe(
                        result => {   //Trả về processId vừa tạo

                            this.router.navigateByUrl("manage-process/process/" + result)
                        },
                        error => {
                            console.log(error);

                        }
                    )



            }
        }



    }
}