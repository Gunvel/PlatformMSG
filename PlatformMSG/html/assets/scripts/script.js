
//Создаем блок с сообщением
function createMessageBlock(owner, message, cl) {
    var mhDiv = document.createElement("div");
    mhDiv.className = 'message_owner';
    mhDiv.innerHTML = owner;

    var mmDiv = document.createElement("div");
    mmDiv.className = 'message_text';
    mmDiv.innerHTML = message;

    var mDiv = document.createElement("div");
    mDiv.className = cl;
    mDiv.append(mhDiv);
    mDiv.append(mmDiv);

    return mDiv;
}

//Добавляем блок с сообщением
function insertMessageBlock(owner, message, cl) {
    let chat = document.getElementById('chat');
    if (chat != null) {
        let block = createMessageBlock(owner, message, cl);
        chat.append(block);

        return true;
    }

    return false;
}


//Когда окно загружено, подписываем кнопки и поле ввода на события клика и нажатие клавишы Enter
window.onload = function () {
    let button = document.getElementById('send');

    if (button != null) {
        button.onclick = addMessage;
    }

    let messageIn = document.getElementById('message');

    if (messageIn != null) {
        messageIn.onkeydown = function (event) {
            if (event.key === "Enter") {
                addMessage();
            }
        };
    }
}

// Добавляем сообщение
function addMessage() {
    let messageIn = document.getElementById('message');
    if (messageIn != null) {
        let message = messageIn.value;
        if (message === "" || !message.trim())
            return;

        if (insertMessageBlock('HTML', message, 'message_html')) {
            messageIn.value = "";

            //Отправляем сообщение хосту
            window.chrome.webview.postMessage({
                Owner: 'HTML',
                Message: message
            });
        }
    }
}

//Прослушиваем сообщения с хоста c#
window.chrome.webview.addEventListener('message', addMessgeFromHost);

//Добавляем сообщение с хоста
function addMessgeFromHost(event) {
    if (event.data === "" || !event.data.trim())
        return;

    let mc = JSON.parse(event.data);
    insertMessageBlock(mc.Owner, mc.Message, 'message_wpf');
}
