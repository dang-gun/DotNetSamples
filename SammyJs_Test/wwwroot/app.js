// 라우트 어플리케이션 생성
var app = Sammy(function () {
    
    //라우트 설정****

    //this.get("", function (context) {
    //    // No route defined, set location to '#/' to trigger app automatically:
    //    location.hash = "/";
    //    location.href = "#/";
    //});

    this.get("#/", function () {
        //인덱스 페이지
        $("#divMain").load("/pages/index.html");
    });

    
    this.get("#/test1", function () {
        $("#divMain").load("/pages/Test1.html");
    });

    this.get("#/test2", function () {
        $("#divMain").load("/pages/Test2.html");
    });

    this.get("#/param/:id", function () {
        //파라미터 받기
        var nID = this.params['id'];

        $("#divMain").html("넘어온 파라미터 id : " + nID);
    });

    //404
    this.notFound = function (verb, path) {
        //인덱스 페이지
        //$("#divMain").load("/pages/index.html");
        $("#divMain").html("404, 페이지 못찾음");
    };
});

//어플리케이션 시작
$(function () {
    app.run()
});