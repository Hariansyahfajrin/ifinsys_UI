function PreviewImage(base64, target) {
  const tab = window.open()
  tab.document.body.innerHTML = `<img src=${base64} width="100%" height="100%" />`
}

function PreviewPDF(base64, target) {
  const tab = window.open()
  tab.document.body.innerHTML = `<object data=${base64} width="100%" height="100%" />`
}

function DownloadFile(base64, fileName) {
    var download = document.createElement('a');
    download.href = base64;
    download.download = fileName;
    document.body.appendChild(download);
    download.click();
    document.body.removeChild(download);
}