//Variables Globales
var nombreApp = "GeronApp";
var appId = "Macaner.GeronAppWeb.Client.Web";
function ShowAlertConfirm() {
    $('#modalAlertConfirm').modal('show');
}

function HideAlertConfirm() {
    $('#modalAlertConfirm').modal('hide');
}

//function MostrarPregunta() {
//    iziToast.question({
//        timeout: 20000,
//        close: false,
//        overlay: true,
//        displayMode: 'once',
//        id: 'question',
//        zindex: 999,
//        title: 'Hey',
//        message: 'Are you sure about that?',
//        position: 'center',
//        displayMode: 2,
//        balloon: true, // Mejora la apariencia de los botones
//        escapeHtml: false, // Permite interpretar HTML en los botones
//        buttons: [
//            ['<button><b>YES</b></button>', function (instance, toast) {

//                instance.hide({ transitionOut: 'fadeOut' }, toast, 'button');

//            }, true],
//            ['<button>NO</button>', function (instance, toast) {

//                instance.hide({ transitionOut: 'fadeOut' }, toast, 'button');

//            }],
//        ],
//        onClosing: function (instance, toast, closedBy) {
//            console.info('Closing | closedBy: ' + closedBy);
//        },
//        onClosed: function (instance, toast, closedBy) {
//            console.info('Closed | closedBy: ' + closedBy);
//        }
//    });
//}

function MostrarPregunta() {
    iziToast.question({
        timeout: 20000,
        close: false,
        overlay: true,
        displayMode: 'once',
        id: 'question',
        zindex: 999,
        title: 'Confirmación',
        message: '¿Estás seguro de continuar?',
        position: 'center',
        displayMode: 2,
        balloon: true,
        escapeHtml: false, // Permite etiquetas HTML en el mensaje
        buttons: [
            ['<button class="btn-yes"><b>SÍ</b></button>', function (instance, toast) {
                instance.hide({ transitionOut: 'fadeOut' }, toast, 'button');
                console.log("El usuario aceptó.");
            }, true],
            ['<button class="btn-no">NO</button>', function (instance, toast) {
                instance.hide({ transitionOut: 'fadeOut' }, toast, 'button');
                console.log("El usuario rechazó.");
            }]
        ],
        onOpening: function (instance, toastRef) {
            setTimeout(() => {
                let toast = document.getElementById('question'); // Obtener el toast manualmente
                if (!toast) return;

                let btnYes = toast.querySelector('.btn-yes');
                let btnNo = toast.querySelector('.btn-no');

                if (btnYes) {
                    btnYes.style.padding = "10px";
                    btnYes.style.border = "none";
                    btnYes.style.background = "#28a745";
                    btnYes.style.color = "white";
                    btnYes.style.cursor = "pointer";
                    btnYes.style.borderRadius = "5px";
                }

                if (btnNo) {
                    btnNo.style.padding = "10px";
                    btnNo.style.border = "none";
                    btnNo.style.background = "#dc3545";
                    btnNo.style.color = "white";
                    btnNo.style.cursor = "pointer";
                    btnNo.style.borderRadius = "5px";
                }
            }, 200);
        },
        onClosing: function (instance, toast, closedBy) {
            console.info('Toast cerrándose | Cerrado por: ' + closedBy);
        },
        onClosed: function (instance, toast, closedBy) {
            console.info('Toast cerrado | Cerrado por: ' + closedBy);
        }
    });
}

function ShowSuccessAlert(message) {
    iziToast.success({
        title: nombreApp + " - Éxito",
        position: "center",
        icon: "fas fa-check",
       displayMode: 2,
        message: message
        
    });
}

function ShowErrorAlert(message) {
    iziToast.error({
        title: nombreApp + " - Error",
        position: "center",
        icon: "fas fa-times",
        displayMode: 2,
        message: message
    });
}
function ShowWarningAlert(message) {
    iziToast.warning({
        title: nombreApp + " - Advertencia",
        position: "center",
        icon: "fas fa-exclamation",
        displayMode: 2,
        escapeHtml: false,
        message: message
    });
    let lastToastBody = document.querySelector(".iziToast:last-child .iziToast-body p");
            if (lastToastBody) {
                lastToastBody.innerHTML = message; // 👈 Solo reemplazamos el contenido del mensaje
            }
}

//function ShowWarningAlert(message) {
//    let toast = iziToast.warning({
//        title: nombreApp + " - Advertencia",
//        position: "center",
//        icon: "fas fa-exclamation",
//        displayMode: 2,
//        message: " ", // 👈 Espacio en blanco para evitar que iziToast lo procese antes de tiempo
//    });

//    setTimeout(() => {
//        let lastToastBody = document.querySelector(".iziToast:last-child .iziToast-body p");
//        if (lastToastBody) {
//            lastToastBody.innerHTML = message; // 👈 Solo reemplazamos el contenido del mensaje
//        }
//    }, 100);
//}

//window.initSelect2 = () => {
//    // Selecciona todos los <select> con clase .select2 y los inicializa
//    $('.select2').select2();
//}

function initSelect2(selector,funcion) {
    $(selector).select2();

    // Captura el evento de cambio y lo envía a Blazor
    $(selector).on('change', function () {
        const selectedValue = $(this).val();

        // Llama a un método de Blazor para actualizar el modelo
        DotNet.invokeMethodAsync(appId, funcion, selectedValue);
    });
}

async function startCamera() {
    //const video = document.getElementById('video');
    //if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
    //    try {
    //        const stream = await navigator.mediaDevices.getUserMedia({ video: true });
    //        video.srcObject = stream;
    //        video.play();
    //    } catch (error) {
    //        console.error('Error al acceder a la cámara: ', error);
    //    }
    //} else {
    //    alert('Tu navegador no soporta acceso a la cámara.');
    //}



    //const video = document.getElementById('video');
    //if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
    //    const stream = await navigator.mediaDevices.getUserMedia({ video: true });
    //    video.srcObject = stream;
    //    video.play();
    //}
    const video = document.getElementById('video');
    const canvas = document.getElementById('canvas');
    canvas.style.display = 'none';

    // Detener el stream actual si ya está activo
    if (video.srcObject) {
        const tracks = video.srcObject.getTracks();
        tracks.forEach(track => track.stop());
        video.srcObject = null;
    }

    // Iniciar un nuevo stream
    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
        try {
            const stream = await navigator.mediaDevices.getUserMedia({ video: true });
            video.srcObject = stream;
            video.style.display = 'block';
            video.play();
        } catch (err) {
            console.error("Error al iniciar la cámara:", err);
        }
    }

}

function takePhoto() {
    //const video = document.getElementById('video');
    //const canvas = document.getElementById('canvas');
    //const context = canvas.getContext('2d');

    //canvas.width = video.videoWidth;
    //canvas.height = video.videoHeight;
    //context.drawImage(video, 0, 0, canvas.width, canvas.height);

    //const dataUrl = canvas.toDataURL('image/png');
    //return dataUrl;


    const video = document.getElementById('video');
    const canvas = document.getElementById('canvas');
    const context = canvas.getContext('2d');

    // Ajusta el tamaño del canvas al tamaño del video
    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;

    // Dibuja la imagen del video en el canvas
    context.drawImage(video, 0, 0, canvas.width, canvas.height);

    // Detiene el flujo de video
    const stream = video.srcObject;
    const tracks = stream.getTracks();
    tracks.forEach(track => track.stop());
    video.srcObject = null;

    // Oculta el video y muestra el canvas con la imagen capturada
    video.style.display = 'none';
    canvas.style.display = 'block';
    return canvas.toDataURL('image/png');
}

function drawImageOnCanvas (canvasId, imageUrl) {
    let canvas = document.getElementById(canvasId);
    let _video = document.getElementById("video");
    _video.style.display = "none";
    canvas.style.display = "block";
    if (!canvas) return;

    let ctx = canvas.getContext("2d");
    let img = new Image();
    img.onload = function () {
        canvas.width = img.width;
        canvas.height = img.height;
        ctx.drawImage(img, 0, 0);
    };
    img.src = imageUrl;
}