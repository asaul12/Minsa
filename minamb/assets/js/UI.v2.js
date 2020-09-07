function MsgAlert(msg) {
    if (msg !== undefined) {
        var notice = PNotify.notice({
            text: msg,
            width: '600px',
            modules: {
                Buttons: {
                    closer: false,
                    sticker: false
                }
            }
        });
        notice.on('click', function () {
            notice.close();
        });
    }
}
function MsgInfo(msg) {
    if (msg !== undefined) {
        var notice = PNotify.info({
            text: msg,
            width: '600px',
            modules: {
                Buttons: {
                    closer: false,
                    sticker: false
                }
            }
        });
        notice.on('click', function () {
            notice.close();
        });
    }
}
function MsgErro(msg) {
    if (msg === undefined) {
        msg = 'Aconteceu um erro ao processar a operação.';
    }
    var notice = PNotify.error({
        text: msg,
        width: '600px',
        modules: {
            Buttons: {
                closer: false,
                sticker: false
            }
        }
    });
    notice.on('click', function () {
        notice.close();
    });
}
function MsgOk(msg) {
    if (msg === undefined) {
        msg = 'Operação processada com exito';
    }

    var notice = PNotify.success({
        text: msg,
        width: '600px',
        modules: {
            Buttons: {
                closer: false,
                sticker: false
            }
        }
    });
    notice.on('click', function () {
        notice.close();
    });
}

function MostrarResultado(res) {
    if (res.Exito === true) {
        MsgOk(res.Mensagem);
    } else {
        MsgErro(res.Mensagem);
    }
}
