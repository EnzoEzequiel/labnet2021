import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Suppliers} from '../models/suppliers'
import {environment} from '../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class SuppliersService {

  constructor(private http: HttpClient) { }

  //Insertar nuevo registro
  postSuppliers(request: Suppliers)
  {
    return this.http.post(environment.suppliers + 'Suppliers/', request);
  }
  //Obtener un solo registro
  readSuppliers(id: number): Observable<Suppliers>
  {
    return this.http.get<any>(environment.suppliers + 'Suppliers/' + id);
  }
  //Obtener la lista de registros
  getSuppliers(): Observable<Suppliers[]>
  {
    return this.http.get<any>(environment.suppliers + 'Suppliers/');
  }
  //Eliminar un solo registro
  deleteSuppliers(id: number): Observable<Suppliers>
  {
    return this.http.delete<any>(environment.suppliers + 'Suppliers/' + id);
  }
  //Modificar un registro
  updateSuppliers(request: Suppliers)
  {
    return this.http.put<any>(environment.suppliers + 'Suppliers/', request);
  }

}
