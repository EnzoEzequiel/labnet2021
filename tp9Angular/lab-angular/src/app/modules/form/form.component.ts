import { invalid } from '@angular/compiler/src/render3/view/util';
import { Component, Inject, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { Suppliers } from '../models/suppliers';
import { SuppliersService } from '../services/suppliers.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit, OnDestroy {

  private sucessSubmit: boolean;

  @Input() supplierChild: Suppliers;
  @Output() messageEvent = new EventEmitter<boolean>();

  private subscription: Subscription;

  form: FormGroup;

  get nameCompanyCtrl(): AbstractControl {
    return this.form.get('companyName');
  }

  get nameCtrl(): AbstractControl {
    return this.form.get('name');
  }

  constructor(private fb: FormBuilder, private saveService: SuppliersService) { }

  ngOnInit(): void {
    this.subscription = new Subscription();
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(40), Validators.pattern('[a-zA-Z ]*')]],
      companyName: ['', [Validators.required, Validators.maxLength(40), Validators.pattern('[a-zA-Z ]*')]]
    });
  }

  onSubmit(): void {
    if(this.supplierChild.SupplierID == null)
    {
      var suppliers = new Suppliers();
      suppliers.CompanyName = this.form.get('companyName').value;
      suppliers.ContactName = this.form.get('name').value;
      this.subscription.add(
      this.saveService.postSuppliers(suppliers).subscribe(
        (response: Suppliers) => {console.log(response)},
        (error: any) => {this.sucessSubmit=false, this.messageEvent.emit(this.sucessSubmit), console.log(error)},
        () => {this.sucessSubmit=true, this.messageEvent.emit(this.sucessSubmit), this.onClear()},
      ));
    }
    else
    {
      this.supplierChild.CompanyName = this.form.get('companyName').value;
      this.supplierChild.ContactName = this.form.get('name').value;
      this.subscription.add(
      this.saveService.updateSuppliers(this.supplierChild).subscribe(
        (response: Suppliers) => {console.log(response)},
        (error: any) => {this.sucessSubmit=false, this.messageEvent.emit(this.sucessSubmit), console.log(error)},
        () => {this.sucessSubmit=true, this.messageEvent.emit(this.sucessSubmit), this.onClear()},
      ));
    }

  }

  onClear(): void {

    console.log(this.form);

    if(this.nameCtrl)
    {
      this.nameCtrl.reset();
    }
    if(this.nameCompanyCtrl)
    {
      this.nameCompanyCtrl.reset();
    }

  }

  ngOnDestroy() {
    this.subscription.unsubscribe;
    console.log("form destroy");
  }

}
