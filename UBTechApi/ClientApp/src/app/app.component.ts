import { Component, OnInit } from '@angular/core';
import { FormControl,Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, of } from 'rxjs';
import { debounceTime, tap, switchMap, finalize } from 'rxjs/operators';
import { ModalDismissReasons, NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ClientSearchService } from './services/client-search.service';


@Component({
  selector: 'client-search',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  searchPersonCtrl = new FormControl();
  filteredPersons: any;
  isLoading = false;
  errorMsg: string;
  selectedValue : string;
  private selectionValid = false;
  private modalOptions: NgbModalOptions;
  private minSearchCharacters : number = 1;

    
  constructor(
    private http: HttpClient,
    private modalService: NgbModal,
    private clientSearchService: ClientSearchService
  ) { }


  public displayProperty(value) {
    if (value) {
      return value.firstName + ' ' + value.lastName;
    }
  }

  ngOnInit() {
    this.searchPersonCtrl.valueChanges
    .pipe(
          debounceTime(500),
          tap(value => {
            this.errorMsg = "";
            this.filteredPersons = [];     
          }),
          switchMap(value => {

              if ((value.length > this.minSearchCharacters) && (this.selectedValue != value)) {
              this.isLoading = true;
              return this.clientSearchService.search(value)
                  .pipe(
                        finalize(() => {
                              this.isLoading = false;
                              this.selectionValid = false;
                        })
              );
            }           
              return [];     
          })         
      )
      .subscribe(
        data => {
                  this.filteredPersons = data;
                  console.log(this.filteredPersons);
       
                },
        err => {
                  console.log(err) ;
                  this.errorMsg = err.message;
               });
  }

  closeResult: string;
  open(content) {
    const modalRef = this.modalService.open(content, this.modalOptions).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;  
    }  
  }

   onSelectionChange(event){
     this.selectedValue = event.option.value;
     this.selectionValid = true;
  }

}



