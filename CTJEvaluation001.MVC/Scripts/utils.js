function convertDateUsToDateBr(date) {
    try {
        var dateArr = date.split('/');
        return dateArr[1] + "/" + dateArr[0] + "/" + dateArr[2];
    } catch (e) {
        return "";
    }
}

function convertDateBrToDateUs(date) {
    try {
        var dateArr = date.split('/');
        return dateArr[1] + "/" + dateArr[0] + "/" + dateArr[2];
    } catch (e) {
        return "";
    }
}