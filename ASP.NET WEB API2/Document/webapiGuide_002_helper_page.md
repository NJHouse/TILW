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
생성되며 필요 구성요서들도 같이 생성된다.
 
