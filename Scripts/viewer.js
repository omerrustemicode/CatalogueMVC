function search() {
    var searchText = document.getElementById('search-text').value;
    var pdfViewer = document.getElementById('pdf-viewer');
    var pdfDoc = pdfjsLib.getDocument(pdfViewer.src);

    pdfDoc.promise.then(function (pdf) {
        for (var pageNum = 1; pageNum <= pdf.numPages; pageNum++) {
            pdf.getPage(pageNum).then(function (page) {
                page.getTextContent().then(function (textContent) {
                    textContent.items.forEach(function (textItem) {
                        if (textItem.str.includes(searchText)) {
                            // Highlight or navigate to the page with the found text
                        }
                    });
                });
            });
        }
    });
}
