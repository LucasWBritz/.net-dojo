$(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/job").build();

    connection.on("SetCounter", function (count) {
        $('#Counter').html('Total executions: ' + count);
    });    

    connection.start();
});