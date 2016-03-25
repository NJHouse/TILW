#Emtpy Project 만들기

ASP.NET WEB API2 개발을 위한 가장 기본적인 작업을 실행 하겠습니다. ASP.NET WEB API2 의 기본 뼈대만
있는 프로젝트를 생성하여 `Hellow ASP.NET WEB API2!` 라는 테스트를 반환하는 메서드를 작성 해
보겠습니다. 데이타의 확인은 [Fiddler](http://www.telerik.com/fiddler) 에서 `Composer` 를 이용해
확인해 보겠습니다. 

####1. 프로젝트 선택 
[그림1]

![그림1](http://i.imgur.com/tzGDjJN.jpg)

`프로젝트 생성` 을 누르면 `새 프로젝트` 대화 상자가 나타나며 좌측 `템플릿` 확장을 합니다. 확장을 하고
또 `Visual C#` 을 확장을 합니다. 확장된 아이템중 `웹` 을 선택합니다.
중앙 영역 상단에 최신 프레임웍 (작성시점에선 .NET Framework 4.6.1) 선택 하고, 그 아래 템플릿
(ASP.NET 웹 응용 프로그램) 을 선택 후 하단 `이름`, `위치`, `솔루션 이름` 을 입력 선택하고 `확인`
버튼을 누릅니다.

####2. 템플릿 선택
[그림2]

![그림2](http://i.imgur.com/7e29t7U.jpg)

`템플릿 선택` 영역에서 `ASP.NET 4.6.1 템플릿` 중 `Empty`를 선택하고 "다음에 대한 폴더 및 핵심 참조 추가"
에 `Web API` 체크박스를 선택 하고 `확인` 버튼을 눌러줍니다.

####3. 탐색기 내용 보기
[그림3]

![그림3](http://i.imgur.com/82yW5wE.jpg)

Empty Project 는 [그림3] 과 같이 구성됩니다.

####4. Web API 호출
라우팅 시스템에 의해 어떤 Web API 액션을 호출할지 결정 되며, 그 기본 라우팅 시스템은 프로젝트 생성시
자동으로 만들어집니다.

`App_Start` 폴더 하위에 `WebApiConfig.cs` 파일의 내에 기본 라우트가 정의되어 있습니다.

 ```csharp
 confing.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
 );
 ```

그럼 `Hellow ASP.NET WEB API2!` 출력해줄 액션 컨트롤러를 만들어 보겠습니다. 커트롤러 이름은 
`HellowController` 로 만들겠습니다.

[그림4]

![그림4](http://i.imgur.com/95wEyak.jpg)

`Controllers` 폴더 에서 마우스 오른쪽 버튼을 클릭후 `추가` > `컨트롤러`를 선택 합니다.
   
 [그림5]
 
 ![그림5](http://i.imgur.com/ehENH9D.jpg)
 
`스캐포드 추가` 대화상자에서 `Web API 2 Controller - Empty` 를 선택 후 `추가` 버튼을 클릭 합니다.

[그림6]

![그림6](http://i.imgur.com/EiXqj9W.jpg)

`Default` 를 `Hellow`로 변경하고 `Add` 버튼을 클릭합니다.

다음과 같이 Get 메서드를 만들어 줍니다.
 ```csharp
 public string Get()
 {
    return "Hellow ASP.NET WEB API2!";
 }
 ```
 
 작성 후 `F5` 혹은 `Ctrl + F5` 눌러 실행합고, `Fiddler` 를 실행합니다.
 
[그림7]

![그림7](http://i.imgur.com/iAMPjWm.jpg)

`Composer` 탭에서 Url 입력 필드에 로컬에 실행된 URL `(htt://localhost:7335/api/Hellow` 을 입력 하고
 오른쪽 끝에 있는 `Execute` 버튼을 클릭합니다.
 
 [그림8]
 
 ![그림8](http://i.imgur.com/3MDC4a3.jpg)
 
 `Inspectors` 탭에서 결과를 확인해 보면 하단 `JSON` 탭에 결과를 확인할 수 있습니다. 