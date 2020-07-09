import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services';
import { CategoryService } from 'src/app/services/category.service';
import { ProcessService } from 'src/app/services/process.service';

@Component({
    selector: 'app-process-action',
    templateUrl: './process-action.component.html',
    styleUrls: ['./process-action.component.css']
})
export class ProcessActionComponent implements OnInit {

    @Input() mode: string;
    @Input() process;

    @ViewChild("nameInput", { read: ElementRef }) nameInput: ElementRef;
    @ViewChild("categoryInput", { read: ElementRef }) categoryInput: ElementRef;
    @ViewChild("descriptionInput", { read: ElementRef }) descriptionInput: ElementRef;

    currentUser;
    listCategory;
    newProcess;
    btnIsLoading: boolean;

    errorMessage: string;
    constructor(
        private route: ActivatedRoute,
        private authenticationService: AuthenticationService,
        private router: Router,
        private categoryService: CategoryService,
        private processService: ProcessService,
    ) {



    }

    ngOnInit(): void {
        if (this.process == null) {
            this.newProcess = {
                name: '',
                description: '',
                category: {
                    createdBy: '',
                    name: ''
                },
                status: 'maintain'
            }
        } else {
            this.newProcess = this.process;
        }

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

    handleKeyUp(e, element, isEnd = false) {

        this.errorMessage = '';
        if (e.keyCode == 13) {
            if (isEnd == true) {
                this.submitProcess(this.mode);
            } else {
                element.focus();
            }

        }
    }

    submitProcess(mode) {

        this.btnIsLoading = true;
        if (this.newProcess.name == '') {
            this.btnIsLoading = false;
            this.errorMessage = "Tên quy trình không được để trống";
            this.nameInput.nativeElement.focus();
            return;
        } else if (this.newProcess.description == '') {
            this.btnIsLoading = false;
            this.errorMessage = "Mô tả không được để trống";
            this.descriptionInput.nativeElement.focus();

         } else {
            if (this.newProcess.category.name == '') {
                this.errorMessage = "Danh mục không được để trống"
                this.categoryInput.nativeElement.focus();
                this.btnIsLoading = false;
                return;
            } else {
                if (mode == 'add') {
                    this.processService.addProcess(this.newProcess)
                        .subscribe(
                            result => {   //Trả về processId vừa tạo
                                this.btnIsLoading = false;
                                this.router.navigateByUrl("manage-process/process/" + result)
                            },
                            error => {
                                console.log(error);

                            }
                        )
                } else {

                    this.processService.updateProcess(this.newProcess)
                        .subscribe(
                            result => {   //Trả về processId vừa tạo
                                this.btnIsLoading = false;
                                // refresh lai trang
                                this.router.navigateByUrl('/manage-process/list-process', { skipLocationChange: true }).then(() => {
                                    this.router.navigateByUrl("manage-process/process/" + result)
                                });

                            },
                            error => {
                                this.btnIsLoading = false;
                                console.log(error);

                            }
                        )

                }

            }


        }
    }

}
