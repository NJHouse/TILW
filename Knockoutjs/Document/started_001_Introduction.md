## Introduction

Knockout 은 데이타 모델과 응답 및 편집기를 이용한 사용자 인터페이스를 작성하는데 있어서 당신에게 많은 도움을<br/>
줄 Javascript Library 입니다. 동적으로 업데이트 되는 UI 를 구현하고 싶을때마다 KO는 쉽게 유지보수 하는데 도움<br/>
이 될 수 있습니다.

주요기능 : 
- <strong>Elegant dependency tracking</strong> - 데이타 모델이 변경될때마다 자동으로 UI 부분을 업데이트합니다.
- <strong>Declarative bindings</strong> - 간단한 방법으로 데이타 모델에 UI의 일부분을 연결합니다. 바인딩 컨텍스트를 사용하여<br/>
복잡한 동적 UI를 구성 할 수 있습니다.
- <strong>Trivially extensible</strong> - 재사용이 가능한 몇줄의 코드로 명시적 바인딩 등의 사용자 정의 동작을 구현합니다.

부가기능 : 
- <strong>Pure JavaScript library</strong> - 서버나 클라이언트 기술로 동작합니다.
- <strong>Can be added on top of your existing web application</strong> - 기존 구조변경 없이 변경 가능합니다.
- <strong>Compact</strong> - Gzip 압축후 크기가 13kb 정도입니다.
- <strong>Works on any mainstream browser</strong> (IE 6+, Firefox 2+, Chrome, Safari, Edge, others)
- <strong>Comprehensive suite of specifications</strong> (developed BDD-style) 새로운 브라우져와 플랫폼 환경에서도
함수를 사용 하는게 쉽습니다.

Ruby on Rails, ASP.NET MVC 또는 MV* 로 된 다른 기술들에 익숙한 개발자들은 선언적 문법으로 된 MVC 의 실시간 형태인 MVVM 을 
볼 수 있습니다. 다른 의미에서, JSON 데이타를 UI로 만들수 있는 방법으로 KO을 생각할 수 있습니다... 당신을 위한 것입니다 :)

#### OK, 어떻게 사용합니까?
빠르고 재미있게 시작하는 방법은 <a href="http://learn.knockoutjs.com/" target="_blank">대화형 자습서</a>를 통해 할 수 있습니다.
기본적인 사항을 학습하고, 관련 <a href="http://knockoutjs.com/examples/index.html" target="_blank">라이브예제</a>를 탐색하고 나면 당신의 프로젝트에 적용할 수 있습니다.

#### KO 는 jQuery 와 함께 작동합니까?
모두가 jQuery를 사랑합니다! DOM API 활용에 있어서 적절한 방법입니다. jQuery는 웹페이지에서 이벤트를 조작하는 
low-level의 좋은 방법입니다. KO는 다른 문제를 해결합니다.
<br/><br/>
UI 의 사사로운 변경과 중복적인 행동일때 jQuery를 사용하는 경우 유지보수가 까다롭고 많은 비용이 발생할 수 있습니다.
예를 들어서 : 5개의 항목이 있고, 그 항목의 수를 실시간 표시하고, 항목의 수가 5보다 작을때 '추가'버튼을 활성화 되는 상황입
니다. jQuery는 특정 CSS 클래스의 DIV 혹은 테이블의 TR 의 수를 알아오는 데이타 모델 개념이 없습니다. 어쩌면 항목의 수는 
Span 에 표실될 수 있습니다. 항목이 변경될 때마다 Span 의 텍스트가 변경되는 것을 고려해야 합니다. 항목이 5인 경우 '추가'
버튼이 비활성화 되는것도 고려해야 합니다. 나중에 '삭제'버튼을 구현한다면, 그 버튼으로 인해서 변경되는 DOM 요소도 파악해야
합니다.

#### Knockout 은 어떻게 다른가?
그것에 대해서 KO는 많이 쉬운편입니다. 적합성 문제에 대한 두려워할 필요가 없이 확장이 가능합니다. 자바스크립트로 배열을
나타내며 그 배열을 Div 에 foreach 바인딩을 사용해 표현합니다. 배열이 변경되면 UI에 맞게 적용됩니다(위치나 새로운 항목
을 주입할 필요가 없습니다). UI는 동기화를 유지합니다. 예를 들어, 다음과 같이 항목의 수를 표시하는 Span 입니다.

```Html
There are <span data-bind="text: myItems().length"></span> items
```

그렇습니다. 항목의 수를 업데이트 하는 코드를 작성할 필요가 없이 `myItems` 배열 변경시 알아서 업데이트합니다. 마찬가지로
항목 수에 따라 '활성', '비활성' 되는 추가 버튼입니다:

```Html
<button data-bind="enable: myItems().length < 5">Add</button>
```

나중에, 삭제 기능을 추가해 달라고 요청이 왔을때, UI에 상호 작용하는 부분을 파악할 필요가 없이 데이타 모델만 변경 합니다.
<br/><br/>
요약하면 : KO는 jQuery 또는 low-level DOM API 와 경쟁하지 않습니다. KO는 high-level의 데이타 모델과 연결하는 보완적인
방법을 제공합니다. KO는 jQuery에 의존하지 않지만, 동시에 jQuery를 사용할 수 있고, 애니메이션 전환 등에 대해서 유용하게
쓰입니다.

원본
- <a href="http://knockoutjs.com/documentation/introduction.html" target="_blank">http://knockoutjs.com/documentation/introduction.html</a>