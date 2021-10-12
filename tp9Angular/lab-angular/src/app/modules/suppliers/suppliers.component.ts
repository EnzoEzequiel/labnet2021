import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Suppliers } from '../models/suppliers';
import { SuppliersService } from '../services/suppliers.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap'
import { Subscription } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit, OnDestroy {

  public cardShow: boolean = false;
  public closeResult = '';

  public listSuppliers: Suppliers[];
  public suppliers: Suppliers;
  public supplierParent: Suppliers;

  private subscription: Subscription;

  formSearch: FormGroup;


  constructor(private formBuilder: FormBuilder,
    private suppliersService:
    SuppliersService,
    private modalService: NgbModal) {
  }

  // Metodos principales..

  ngOnInit(): void {
    this.subscription = new Subscription();
    this.supplierParent = new Suppliers();
    this.suppliers = new Suppliers();
    this.formSearch = this.formBuilder.group({
      search: new FormControl('', Validators.required)
    }),
    this.getSuppliers();
  }

  searchSuppliers(event) {
    this.subscription.add(
      this.suppliersService.readSuppliers(event).subscribe(
        resp => {

          this.suppliers = resp;

        },
        error => { console.log(error), Swal.fire('Algo salio mal!','No se encontro el registro solicitado!', 'error') },
        () => {this.cardShow = true},
      ))
  }

  getSuppliers() {
    this.subscription.add(
      this.suppliersService.getSuppliers().subscribe(
        resp => {
          this.listSuppliers = resp;
        },
        error => { alert("Ocurrio un error al mostrar los datos!") }));
  }

  deleteSupplier(id: number) {
    this.subscription.add(
      this.suppliersService.deleteSuppliers(id).subscribe(
        resp => {
          console.log(resp);
        },
        (error: any) => Swal.fire('Algo salio mal!','No se pudo eliminar el registro solicitado!', 'error'),
        () => {
          Swal.fire('Yeah!', 'Empleado eliminado con exito!', 'success')
          this.getSuppliers()
        },
      ));
  }

  // Metodos secundarios..

  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.resetSupplier();
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

  receiveMessage($event) {
    if ($event) {
      Swal.fire('Yeah!', 'Operación exitosa!', 'success')
      this.getSuppliers();
    }
    else {
      Swal.fire("La operación fallo!", 'error');
    }
  }

  getUpdate(supplier: Suppliers) {
    this.supplierParent.SupplierID = supplier.SupplierID;
    this.supplierParent.CompanyName = supplier.CompanyName;
    this.supplierParent.ContactName = supplier.ContactName;
  }

  closeCard() {
    this.cardShow = false;
  }

  resetSupplier() {
    this.supplierParent.SupplierID = null;
    this.supplierParent.CompanyName = null;
    this.supplierParent.ContactName = null;
  }

  handleWarningAlert(id: number) {

    Swal.fire({
      title: 'Estas seguro?',
      text: 'No podras recuperar este registro!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Si, eliminar!',
      cancelButtonText: 'No, mantener',
    }).then((result) => {

      if (result.isConfirmed) {

        this.deleteSupplier(id);

      }
    })

  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    console.log("main destroy");
  }


}
