"use strict";(self.webpackChunkxtreme_admin_angular=self.webpackChunkxtreme_admin_angular||[]).push([[590],{7590:(F,u,a)=>{a.r(u),a.d(u,{SeguimientoPacienteModule:()=>y});var g=a(6895),r=a(4006),f=a(911),S=a(9340),p=a(2654),v=a(4691),s=a(6137),P=a(13),t=a(4650),h=a(6013),d=a(3609),b=a(6541);function x(n,l){if(1&n){const e=t.EpF();t.TgZ(0,"tr")(1,"td"),t._uU(2),t.qZA(),t.TgZ(3,"td"),t._uU(4),t.qZA(),t.TgZ(5,"td"),t._uU(6),t.qZA(),t.TgZ(7,"td"),t._uU(8),t.qZA(),t.TgZ(9,"td")(10,"a",17),t.NdJ("click",function(){const m=t.CHM(e).$implicit,c=t.oxw(),A=t.MAs(30);return t.KtG(c.openModal(A,m))}),t._UZ(11,"i-feather",18),t.qZA(),t.TgZ(12,"a",19),t.NdJ("click",function(){const m=t.CHM(e).$implicit,c=t.oxw();return t.KtG(c.delete(m.sepId))}),t._UZ(13,"i-feather",20),t.qZA()()()}if(2&n){const e=l.$implicit;t.xp6(2),t.hij("",e.usuNombres," "),t.xp6(2),t.hij("",e.sepFinalizar," "),t.xp6(2),t.hij("",e.sepObservacion," "),t.xp6(2),t.hij("",e.citEstado?"Activo":"Inactivo"," ")}}function C(n,l){if(1&n){const e=t.EpF();t.TgZ(0,"div",21)(1,"h5",22),t._uU(2),t.qZA(),t.TgZ(3,"button",23),t.NdJ("click",function(){t.CHM(e);const o=t.oxw();return t.KtG(o.closeBtnClick())}),t.TgZ(4,"span",24),t._uU(5,"\xd7"),t.qZA()()(),t.TgZ(6,"div",25)(7,"form",26),t.NdJ("ngSubmit",function(){t.CHM(e);const o=t.oxw();return t.KtG(o.onSubmit())}),t.TgZ(8,"div",27)(9,"button",28),t.NdJ("click",function(){t.CHM(e);const o=t.oxw();return t.KtG(o.closeBtnClick())}),t._uU(10,"Cerrar"),t.qZA(),t.TgZ(11,"button",29),t._uU(12,"Guardar"),t.qZA()()()()}if(2&n){const e=t.oxw();t.xp6(2),t.hij("",e.anadirEditar," SeguimientoPaciente"),t.xp6(5),t.Q6J("formGroup",e.itemForm),t.xp6(4),t.Q6J("disabled",e.itemForm.invalid)}}const Z=[{path:"",data:{title:"SeguimientoPaciente",urls:[]},children:[{path:"",component:(()=>{class n{constructor(e,i,o,m){this.httpService=e,this.notifierService=i,this.modalService=o,this.fb=m,this.indexParameters=new S.p,this.itemsSub=new p.w,this.items=[],this.search=new r.p4("",[]),this.formsErrors=[],this.itemSub=new p.w,this.anadirEditar="A\xf1adir",this.notifier=i}ngOnInit(){this.itemForm=this.fb.group({sepId:[0],sepObservacion:[null,r.kI.required],sepFinalizar:[null,r.kI.required]}),this.indexParameters.length=s.Kz.count,this.indexParameters.pageSize=s.Kz.quantity,this.indexParameters.quantity=s.Kz.quantity,this.indexParameters.pageIndex=s.Kz.page,this.indexParameters.modulo=s.qz.seguimientoPaciente.name,this.indexParameters.actionResult=void 0,this.search.valueChanges.pipe((0,P.b)(350)).subscribe(e=>{this.indexParameters.search=e&&e.trim()?e:void 0,this.getItems()}),this.getItems(),this.preguntas=[]}ngOnDestroy(){this.itemsSub.unsubscribe(),this.itemSub.unsubscribe()}getItems(){this.itemsSub=this.httpService.getItems(this.indexParameters).subscribe(e=>{this.items=e?.data?.elementos,this.indexParameters.length=e?.data?.cantidadElementos,this.items&&0==this.items.length&&this.notifier.notify("warning","No hay datos para mostrar")})}changePagination(e){this.indexParameters.page=e,this.getItems()}openModal(e,i){this.modalService.open(e,{centered:!0,backdrop:"static"}),null!=i?(this.anadirEditar="Editar",this.getDataForm(i.sepId)):this.getDataForm(0)}logValidationErrors(e){}closeBtnClick(){this.modalService.dismissAll(),this.ngOnInit()}getDataForm(e){this.itemSub=this.httpService.GetDataForm(e,void 0,s.qz.seguimientoPaciente.name).subscribe(i=>{this.preguntas=i.data?.preguntas,i.data?.data&&this.itemForm.patchValue(i.data?.data)})}onSubmit(){this.itemForm.invalid?this.itemForm.markAllAsTouched():this.itemsSub=this.httpService.PostPut(this.itemForm.value,s.qz.seguimientoPaciente.name,!1,void 0,this.itemForm.value.sepId).subscribe(e=>{this.closeBtnClick(),this.notifier.notify("success","Se ha registrado los datos correctamente")})}delete(e){let i=[];i.push(e),this.itemsSub=this.httpService.deleteItems(s.qz.seguimientoPaciente.name,void 0,i).subscribe(o=>{this.closeBtnClick(),this.notifier.notify("success","El dato se ha eliminado")})}buscarPreguntas(e){[].push(e),this.itemsSub=this.httpService.GetByIdList(e,0,s.qz.catalogoSeguimiento.name,"GetList").subscribe(o=>{this.preguntas=o})}}return n.\u0275fac=function(e){return new(e||n)(t.Y36(v.O),t.Y36(h.lG),t.Y36(d.FF),t.Y36(r.QS))},n.\u0275cmp=t.Xpm({type:n,selectors:[["app-seguimientoPaciente"]],decls:31,vars:5,consts:[[1,"row"],[1,"col-md-12"],[1,"card"],[1,"card-body"],[1,"col-md-6","col-lg-3","col-xl-2"],["type","text","type","text","name","search","placeholder","Buscar SeguimientoPaciente",1,"form-control","form-control-lg",3,"formControl"],[1,"col-md-6","col-lg-9","col-xl-10","text-md-right","mt-4","mt-md-0"],[1,"btn","btn-primary","ml-auto",3,"click"],[1,"col-12"],[1,"card","card-body"],[1,"table-responsive","table-bordered"],[1,"table","table-striped","mb-0","no-wrap","v-middle"],["scope","col"],[4,"ngFor","ngForOf"],[1,"justify-content-center","mt-2"],["maxSize","20","size","sm","rotate","true",3,"page","pageSize","collectionSize","pageChange"],["itemFormModal",""],["href","javascript: void(0);","placement","top","ngbTooltip","Editar",1,"link","mr-2",3,"click"],["name","edit-2",1,"feather-sm"],["href","javascript: void(0);","placement","top","ngbTooltip","Eliminar",1,"link",3,"click"],["name","trash-2",1,"feather-sm"],[1,"modal-header"],["id","itemFormLabel",1,"modal-title"],["type","button","aria-label","Close",1,"close",3,"click"],["aria-hidden","true"],[1,"modal-body"],[3,"formGroup","ngSubmit"],[1,"modal-footer"],["type","button",1,"btn","btn-secondary",3,"click"],["type","submit",1,"btn","btn-primary",3,"disabled"]],template:function(e,i){if(1&e){const o=t.EpF();t.TgZ(0,"div",0)(1,"div",1)(2,"div",2)(3,"div",3)(4,"div",0)(5,"div",4),t._UZ(6,"input",5),t.qZA(),t.TgZ(7,"div",6)(8,"button",7),t.NdJ("click",function(){t.CHM(o);const c=t.MAs(30);return t.KtG(i.openModal(c,null))}),t._uU(9,"A\xf1adir SeguimientoPaciente"),t.qZA()()()()()()(),t.TgZ(10,"div",0)(11,"div",8)(12,"div",9)(13,"div",10)(14,"table",11)(15,"thead")(16,"tr")(17,"th",12),t._uU(18,"Cita"),t.qZA(),t.TgZ(19,"th",12),t._uU(20,"Seguimiento"),t.qZA(),t.TgZ(21,"th",12),t._uU(22,"Observaciones"),t.qZA(),t.TgZ(23,"th",12),t._uU(24,"Acciones"),t.qZA()()(),t.TgZ(25,"tbody"),t.YNc(26,x,14,4,"tr",13),t.qZA()()(),t.TgZ(27,"div",14)(28,"ngb-pagination",15),t.NdJ("pageChange",function(c){return i.indexParameters.pageIndex=c})("pageChange",function(c){return i.changePagination(c)}),t.qZA()()()()(),t.YNc(29,C,13,3,"ng-template",null,16,t.W1O)}2&e&&(t.xp6(6),t.Q6J("formControl",i.search),t.xp6(20),t.Q6J("ngForOf",i.items),t.xp6(2),t.Q6J("page",i.indexParameters.pageIndex)("pageSize",i.indexParameters.pageSize)("collectionSize",i.indexParameters.length))},dependencies:[g.sg,r._Y,r.Fj,r.JJ,r.JL,r.oH,r.sg,d.N9,d._L,b.uy],styles:[".viewport[_ngcontent-%COMP%]  video{width:100%;height:240px;-o-object-fit:cover;object-fit:cover}.tabla-detalle-popup[_ngcontent-%COMP%]{width:100%;text-align:left!important}.image[_ngcontent-%COMP%]{display:block;margin-left:auto;margin-right:auto}.cursor-pointer[_ngcontent-%COMP%]{cursor:pointer}.table[_ngcontent-%COMP%]   th[_ngcontent-%COMP%]{width:50%!important}.textoPrimeraLetraMinuscula[_ngcontent-%COMP%]{text-transform:capitalize}"]}),n})()}]}];var _=a(6311),T=a(5074);let y=(()=>{class n{}return n.\u0275fac=function(e){return new(e||n)},n.\u0275mod=t.oAB({type:n}),n.\u0275inj=t.cJS({providers:[h.lG],imports:[g.ez,r.UX,d.IJ,d.bz,f.Bz.forChild(Z),r.u5,_.Xd,b.p1.pick(T.kEt)]}),n})()}}]);