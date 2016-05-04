#Helper Page 만들기

ASP.NET WEB API2 에서는 개발한 API 에 대한 도움말 페이지를 생성하는것이 용이
하다. 협업시 다른 개발자와의 커뮤니케이션에 많은 도움을 줄 것이라 생각되며, 
Helper Page 는 수동 및 자동으로 생성 가능하다.

####Nuget 설치
Nuget 콘솔 및 Nuget 패키지 관리자에서 ` Microsoft.AspNet.WebApi.HelpPage' 
Plugin 을 설치한다. (vs2015 기준) 
```
PM> Install-Package Microsoft.AspNet.WebApi.HelpPage
```

설치하면 프로젝트 루트에 `Areas` 폴더가 생기고 그 하위에 `HelpPage` 폴더가
생성되며 필요 구성요서들도 [그림1]과 같이 생성된다.
 
 ![그림1](http://i.imgur.com/mXWK6PA.jpg)
 
 설치 후 스캐폴딩 기능을 통해 API Controller 를 생성해 보면, 자동으로 Helper Page
 가 만들어지며 내용도 볼 수 있다.
 
 [그림2] read/write 액션을 포함한 API Controller 생성
 
 ![그림2](http://i.imgur.com/koEtuxp.jpg)
 
 [그림3] Controller 이름 설정
 
 ![그림3](http://i.imgur.com/jvHo7jA.jpg)
 
 [그림4] 스캐폴딩 기능으로 자동 생성된 액션들
 
 ![그림4](http://i.imgur.com/66G8Hav.jpg)
 
 [그림5-6] Helper Page
 
 ![그림5](http://i.imgur.com/plIxDGp.jpg)
 
 ![그림6](http://i.imgur.com/wjx8wTc.jpg)