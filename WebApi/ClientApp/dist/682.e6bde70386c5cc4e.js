"use strict";(self.webpackChunkxtreme_admin_angular=self.webpackChunkxtreme_admin_angular||[]).push([[682],{8682:(P,p,a)=>{a.r(p),a.d(p,{MedicosEspecialidadeModule:()=>F});var u=a(6895),n=a(4006),b=a(911),v=a(9340),h=a(2654),E=a(4691),c=a(6137),_=a(13),e=a(4650),g=a(6013),m=a(3609),f=a(6541);function x(o,d){if(1&o){const t=e.EpF();e.TgZ(0,"tr")(1,"td"),e._uU(2),e.qZA(),e.TgZ(3,"td"),e._uU(4),e.qZA(),e.TgZ(5,"td"),e._uU(6),e.qZA(),e.TgZ(7,"td")(8,"a",17),e.NdJ("click",function(){const l=e.CHM(t).$implicit,r=e.oxw(),y=e.MAs(30);return e.KtG(r.openModal(y,l))}),e._UZ(9,"i-feather",18),e.qZA(),e.TgZ(10,"a",19),e.NdJ("click",function(){const l=e.CHM(t).$implicit,r=e.oxw();return e.KtG(r.delete(l.mesId))}),e._UZ(11,"i-feather",20),e.qZA()()()}if(2&o){const t=d.$implicit;e.xp6(2),e.hij("",t.medNombres," "),e.xp6(2),e.hij("",t.espNombre," "),e.xp6(2),e.hij("",t.mesEstado?"Activo":"Inactivo"," ")}}function Z(o,d){if(1&o&&(e.TgZ(0,"option",41),e._uU(1),e.qZA()),2&o){const t=d.$implicit;e.Q6J("value",t.id),e.xp6(1),e.hij(" ",null==t?null:t.nombre,"")}}function C(o,d){if(1&o&&(e.TgZ(0,"option",41),e._uU(1),e.qZA()),2&o){const t=d.$implicit;e.Q6J("value",t.id),e.xp6(1),e.hij(" ",null==t?null:t.nombre,"")}}function M(o,d){if(1&o){const t=e.EpF();e.TgZ(0,"div",21)(1,"h5",22),e._uU(2),e.qZA(),e.TgZ(3,"button",23),e.NdJ("click",function(){e.CHM(t);const s=e.oxw();return e.KtG(s.closeBtnClick())}),e.TgZ(4,"span",24),e._uU(5,"\xd7"),e.qZA()()(),e.TgZ(6,"div",25)(7,"form",26),e.NdJ("ngSubmit",function(){e.CHM(t);const s=e.oxw();return e.KtG(s.onSubmit())}),e.TgZ(8,"div",27)(9,"label",28),e._uU(10,"M\xe9dico *"),e.qZA(),e.TgZ(11,"div",29)(12,"select",30)(13,"option",31),e._uU(14,"Seleccionar "),e.qZA(),e.YNc(15,Z,2,2,"option",32),e.qZA()()(),e.TgZ(16,"div",27)(17,"label",33),e._uU(18,"Especialidad *"),e.qZA(),e.TgZ(19,"div",29)(20,"select",34)(21,"option",31),e._uU(22,"Seleccionar "),e.qZA(),e.YNc(23,C,2,2,"option",32),e.qZA()()(),e.TgZ(24,"div",27)(25,"div",35),e._UZ(26,"input",36),e.TgZ(27,"label",37),e._uU(28,"Activo"),e.qZA()()(),e.TgZ(29,"div",38)(30,"button",39),e.NdJ("click",function(){e.CHM(t);const s=e.oxw();return e.KtG(s.closeBtnClick())}),e._uU(31,"Cerrar"),e.qZA(),e.TgZ(32,"button",40),e._uU(33,"Guardar"),e.qZA()()()()}if(2&o){const t=e.oxw();e.xp6(2),e.hij("",t.anadirEditar," MedicosEspecialidade"),e.xp6(5),e.Q6J("formGroup",t.itemForm),e.xp6(8),e.Q6J("ngForOf",t.medicos),e.xp6(8),e.Q6J("ngForOf",t.medicosEspecialidad),e.xp6(9),e.Q6J("disabled",t.itemForm.invalid)}}const T=[{path:"",data:{title:"MedicosEspecialidade",urls:[]},children:[{path:"",component:(()=>{class o{constructor(t,i,s,l){this.httpService=t,this.notifierService=i,this.modalService=s,this.fb=l,this.indexParameters=new v.p,this.itemsSub=new h.w,this.items=[],this.search=new n.p4("",[]),this.formsErrors=[],this.itemSub=new h.w,this.anadirEditar="A\xf1adir",this.notifier=i}ngOnInit(){this.itemForm=this.fb.group({mesId:[0],UsuId:[0],espId:[0],mesEstado:[!0]}),this.indexParameters.length=c.Kz.count,this.indexParameters.pageSize=c.Kz.quantity,this.indexParameters.quantity=c.Kz.quantity,this.indexParameters.pageIndex=c.Kz.page,this.indexParameters.modulo=c.qz.medicosEspecialidade.name,this.indexParameters.actionResult=void 0,this.search.valueChanges.pipe((0,_.b)(350)).subscribe(t=>{this.indexParameters.search=t&&t.trim()?t:void 0,this.getItems()}),this.getItems(),this.medicos=[],this.medicosEspecialidad=[]}ngOnDestroy(){this.itemsSub.unsubscribe(),this.itemSub.unsubscribe()}getItems(){this.itemsSub=this.httpService.getItems(this.indexParameters).subscribe(t=>{this.items=t?.data?.elementos,this.indexParameters.length=t?.data?.cantidadElementos,this.items&&0==this.items.length&&this.notifier.notify("warning","No hay datos para mostrar")})}changePagination(t){this.indexParameters.page=t,this.getItems()}openModal(t,i){this.modalService.open(t,{centered:!0,backdrop:"static"}),null!=i?(this.anadirEditar="Editar",this.getDataForm(i.mesId)):this.getDataForm(0)}logValidationErrors(t){}closeBtnClick(){this.modalService.dismissAll(),this.ngOnInit()}getDataForm(t){this.itemSub=this.httpService.GetDataForm(t,void 0,c.qz.medicosEspecialidade.name).subscribe(i=>{this.medicos=i.data?.medicos,this.medicosEspecialidad=i.data?.medicosEspecialidad,i.data?.data&&(this.itemForm.patchValue(i.data?.data),this.itemForm.patchValue({mesEstado:(0,c.kp)(i.data?.data.mesEstado)}))})}onSubmit(){this.itemForm.invalid?this.itemForm.markAllAsTouched():(this.itemForm.patchValue({mesEstado:(0,c.ID)(this.itemForm.value.mesEstado)}),this.itemsSub=this.httpService.PostPut(this.itemForm.value,c.qz.medicosEspecialidade.name,!1,void 0,this.itemForm.value.mesId).subscribe(t=>{this.closeBtnClick(),this.notifier.notify("success","Se ha registrado los datos correctamente")}))}delete(t){let i=[];i.push(t),this.itemsSub=this.httpService.deleteItems(c.qz.medicosEspecialidade.name,void 0,i).subscribe(s=>{this.closeBtnClick(),this.notifier.notify("success","El dato se ha eliminado")})}}return o.\u0275fac=function(t){return new(t||o)(e.Y36(E.O),e.Y36(g.lG),e.Y36(m.FF),e.Y36(n.QS))},o.\u0275cmp=e.Xpm({type:o,selectors:[["app-medicosEspecialidade"]],decls:31,vars:5,consts:[[1,"row"],[1,"col-md-12"],[1,"card"],[1,"card-body"],[1,"col-md-6","col-lg-3","col-xl-2"],["type","text","type","text","name","search","placeholder","Buscar MedicosEspecialidade",1,"form-control","form-control-lg",3,"formControl"],[1,"col-md-6","col-lg-9","col-xl-10","text-md-right","mt-4","mt-md-0"],[1,"btn","btn-primary","ml-auto",3,"click"],[1,"col-12"],[1,"card","card-body"],[1,"table-responsive","table-bordered"],[1,"table","table-striped","mb-0","no-wrap","v-middle"],["scope","col"],[4,"ngFor","ngForOf"],[1,"justify-content-center","mt-2"],["maxSize","20","size","sm","rotate","true",3,"page","pageSize","collectionSize","pageChange"],["itemFormModal",""],["href","javascript: void(0);","placement","top","ngbTooltip","Editar",1,"link","mr-2",3,"click"],["name","edit-2",1,"feather-sm"],["href","javascript: void(0);","placement","top","ngbTooltip","Eliminar",1,"link",3,"click"],["name","trash-2",1,"feather-sm"],[1,"modal-header"],["id","itemFormLabel",1,"modal-title"],["type","button","aria-label","Close",1,"close",3,"click"],["aria-hidden","true"],[1,"modal-body"],[3,"formGroup","ngSubmit"],[1,"form-group","row"],["for","UsuId",1,"col-sm-4","col-form-label"],[1,"col-sm-8"],["formControlName","UsuId","id","UsuId",1,"custom-select"],["value",""],[3,"value",4,"ngFor","ngForOf"],["for","espId",1,"col-sm-4","col-form-label"],["formControlName","espId","id","espId",1,"custom-select"],[1,"custom-control","custom-checkbox","mr-sm-2"],["type","checkbox","id","checkbox1","formControlName","mesEstado",1,"custom-control-input"],["for","checkbox1",1,"custom-control-label"],[1,"modal-footer"],["type","button",1,"btn","btn-secondary",3,"click"],["type","submit",1,"btn","btn-primary",3,"disabled"],[3,"value"]],template:function(t,i){if(1&t){const s=e.EpF();e.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",0)(5,"div",4),e._UZ(6,"input",5),e.qZA(),e.TgZ(7,"div",6)(8,"button",7),e.NdJ("click",function(){e.CHM(s);const r=e.MAs(30);return e.KtG(i.openModal(r,null))}),e._uU(9,"A\xf1adir MedicosEspecialidade"),e.qZA()()()()()()(),e.TgZ(10,"div",0)(11,"div",8)(12,"div",9)(13,"div",10)(14,"table",11)(15,"thead")(16,"tr")(17,"th",12),e._uU(18,"M\xe9dico"),e.qZA(),e.TgZ(19,"th",12),e._uU(20,"Especialidad"),e.qZA(),e.TgZ(21,"th",12),e._uU(22,"Estado"),e.qZA(),e.TgZ(23,"th",12),e._uU(24,"Acciones"),e.qZA()()(),e.TgZ(25,"tbody"),e.YNc(26,x,12,3,"tr",13),e.qZA()()(),e.TgZ(27,"div",14)(28,"ngb-pagination",15),e.NdJ("pageChange",function(r){return i.indexParameters.pageIndex=r})("pageChange",function(r){return i.changePagination(r)}),e.qZA()()()()(),e.YNc(29,M,34,5,"ng-template",null,16,e.W1O)}2&t&&(e.xp6(6),e.Q6J("formControl",i.search),e.xp6(20),e.Q6J("ngForOf",i.items),e.xp6(2),e.Q6J("page",i.indexParameters.pageIndex)("pageSize",i.indexParameters.pageSize)("collectionSize",i.indexParameters.length))},dependencies:[u.sg,n._Y,n.YN,n.Kr,n.Fj,n.Wl,n.EJ,n.JJ,n.JL,n.oH,n.sg,n.u,m.N9,m._L,f.uy],styles:[".viewport[_ngcontent-%COMP%]  video{width:100%;height:240px;-o-object-fit:cover;object-fit:cover}.tabla-detalle-popup[_ngcontent-%COMP%]{width:100%;text-align:left!important}.image[_ngcontent-%COMP%]{display:block;margin-left:auto;margin-right:auto}.cursor-pointer[_ngcontent-%COMP%]{cursor:pointer}.table[_ngcontent-%COMP%]   th[_ngcontent-%COMP%]{width:50%!important}.textoPrimeraLetraMinuscula[_ngcontent-%COMP%]{text-transform:capitalize}"]}),o})()}]}];var A=a(6311),S=a(5074);let F=(()=>{class o{}return o.\u0275fac=function(t){return new(t||o)},o.\u0275mod=e.oAB({type:o}),o.\u0275inj=e.cJS({providers:[g.lG],imports:[u.ez,n.UX,m.IJ,m.bz,b.Bz.forChild(T),n.u5,A.Xd,f.p1.pick(S.kEt)]}),o})()}}]);