var dotNetObjRef;
window.onBlazorReady = (dataRef, netObjRef) => {
    dotNetObjRef = netObjRef;

    $.getScript("https://npmcdn.com/flatpickr@4.6.13/dist/l10n/" + dataRef.locale + ".js", function () {
        setDatePicker(dataRef);
    });
};

setDatePicker = (dataRef) => {
    flatpickr(`#${dataRef.id}`, {
        locale: dataRef.locale,
        altInput: dataRef.altInput,
        altFormat: dataRef.altFormat,
        onChange: (selectedDates, dateStr, instance) => {
            dotNetObjRef.invokeMethodAsync("DateChangedInterop", dateStr);
        }
    });
}

jQuery.loadScript = function (url, callback) {
    jQuery.ajax({
        url: url,
        dataType: 'script',
        success: callback,
        async: true
    });
}
