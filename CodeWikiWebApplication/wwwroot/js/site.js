

function getLastCodeInfo() {
    $.get("CodeInfos/Last", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);

        document.getElementById("lastCodeInfo").innerHTML = data;
    });
}