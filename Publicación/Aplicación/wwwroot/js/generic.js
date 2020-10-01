function mostrarModal(titulo = "Desea guardar los cambios?",
	texto = "Deseas registrar los cambios en la base de datos") {
return 	Swal.fire({
		title: titulo,
		text: texto,
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#3085d6',
		cancelButtonColor: '#d33',
		confirmButtonText: 'Si!'
	})
}

function Imprimir() {
	//<table><thead></thead><tbody></tbody></table>
	var tcheck = document.getElementById("tcheck").outerHTML;
	var table = "<h1>Reporte a Imprimir</h1>"
	table += document.getElementById("table").outerHTML;
	table = table.replace(tcheck, "");
	var pagina = window.document.body;
	var ventana = window.open();
	ventana.document.write(table);
	ventana.print();
	ventana.close();
	window.document.body = pagina;
}

window.onload = function () {
	$(document).ready(function () {
		$('#table').DataTable();
	});
}


function ExportarExcel() {
	document.getElementById("tipoReporte").value = "Excel";
	var frmReporte = document.getElementById("frmReporte");
	frmReporte.submit();

}



function ExportarWord() {
	document.getElementById("tipoReporte").value = "Word";
	var frmReporte = document.getElementById("frmReporte");
	frmReporte.submit();
}

function ExportarPDF(nombreController) {
	/*
	document.getElementById("tipoReporte").value = "PDF";
	var frmReporte = document.getElementById("frmReporte");
	frmReporte.submit();
	*/
	var frm = new FormData();
	var checks = document.getElementsByName("nombrePropiedades");
	var nchecks = checks.length;
	for (var i = 0; i < nchecks; i++) {
		if (checks[i].checked == true) {
			frm.append("nombrePropiedades[]", checks[i].value);
		}
	}

	$.ajax({
		type: "POST",
		url: nombreController+"/exportarDatosPDF",
		data: frm,
		contentType: false,
		processData: false,
		success: function (data) {
			//base64 (Descargas ese base 64)
			var a = document.createElement("a");
			a.href = data;
			a.download = "reporte.pdf";
			a.click();
		}
	})


}


function pintar(url, campos, propiedadId, nombreController,
	popup = false, opciones = true, id = "tbDatos",idTabla="table",propiedadMostrar="") {
	var contenido = "";
	if (id == null || id == undefined || id == "") {
		var tbody = document.getElementById("tbDatos");
	} else {
		var tbody = document.getElementById(id);
	}

	var nombreCampo;
	var objetoActual;
	$.get(url, function (data) {

		for (var i = 0; i < data.length; i++) {
			contenido += "<tr>";
			for (var j = 0; j < campos.length; j++) {
				nombreCampo = campos[j];
				objetoActual = data[i];
				contenido += "<td>" + objetoActual[nombreCampo] + "</td>"
			}
			//contenido += "<td>" + data[i].iidespecialidad + "</td>";
			// data[i][iidespecialidad]
			//contenido += "<td>" + data[i].nombre + "</td>";
			//contenido += "<td>" + data[i].descripcion + "</td>";
			if (opciones == true) {
				contenido += `
					<td>

						<i class="fa fa-trash btn btn-danger" aria-hidden="true"
						   onclick="Eliminar(${objetoActual[propiedadId]})">

						</i>`;
				if (popup == false) {
					contenido += `
						
						<a  
						   href="${nombreController}/Editar/${objetoActual[propiedadId]}"
						  >
								<i class="fa fa-edit btn btn-primary"
										aria-hidden="true"
                                  ></i>	
						</a>

					
                 `
				} else {

					contenido += `
	                    <i class="fa fa-edit btn btn-primary" aria-hidden="true"
						   data-toggle="modal"  data-target="#exampleModal"
						   onclick="Abrir(${objetoActual[propiedadId]})">

						</i>


                        `;
				}
				contenido += `</td>`;
			} else {
				contenido += `
					<td>

						<i class="fa fa-check btn btn-success" aria-hidden="true"
						   onclick="AsignarNombre(${objetoActual[propiedadId]},
                              '${objetoActual[propiedadMostrar]}')">

						</i>
					</td>`;
			}
			contenido += "</tr>";
		}


		tbody.innerHTML = contenido;
		if (idTabla == null || idTabla == undefined || idTabla == "") {
			$('#table').DataTable();
		} else {
			$('#' + idTabla).DataTable();
		}
		
	})
}

function pintarMultiplePopup(divTabla,url, cabeceras = ["Id","Descripcion"],
	campos, propiedadId,propiedadMostrar = "") {

	var contenido = "";
	$.get(url, function (data) {

		//Esto
		contenido += "<table id='tablaPopup'>";
		contenido += "<thead>";
		contenido += "<tr>";
		for (var i = 0; i < cabeceras.length; i++) {
			contenido += "<th>" + cabeceras[i] + "</th>"
		}
		contenido += "<th></th>";
		contenido += "</tr>";
		contenido += "</thead>";
		contenido += "<tbody>";
		var objetoActual;
		for (var i = 0; i < data.length; i++) {
			contenido += "<tr>";
			for (var j = 0; j < campos.length; j++) {
				nombreCampo = campos[j];
				objetoActual = data[i];
				contenido += "<td>" + objetoActual[nombreCampo] + "</td>"
			}

			contenido += `
					<td>

						<i class="fa fa-check btn btn-success" aria-hidden="true"
						   onclick="AsignarNombre(${objetoActual[propiedadId]},
                              '${objetoActual[propiedadMostrar]}')">

						</i>
					</td>`;

			contenido += "</tr>";
		}
		contenido += "</tbody>";
		contenido += "</table>";
		document.getElementById(divTabla).innerHTML = contenido;
		$('#tablaPopup').DataTable();
	});
	
	
}

function correcto(title="Se elimino correctamente") {
	
	Swal.fire({
		position: 'top-end',
		icon: 'success',
		title: title,
		showConfirmButton: false,
		timer: 1500
	})


}

function error(title="Ocurrio un error") {

	Swal.fire({
		icon: 'error',
		title: 'Oops...',
		text: title
		
	})
}


function LimpiarDatos() {
	var controles = document.getElementsByClassName("form-control");
	var ncontroles = controles.length;
	for (var i = 0; i < ncontroles; i++) {
		controles[i].value = "";
	}
}

function obj(id, valor) {
	document.getElementById(id).value = valor;
}

function enviar(frm) {
	var controles = document.getElementsByClassName("enviar");
	var ncontroles = controles.length;
	for (var i = 0; i < ncontroles; i++) {
		frm.append(controles[i].name, controles[i].value);
	}
}