## RequireJS(AMD) 이용시 외부에서 접근 방법

KnockoutJS(일명 KO) 와 RequireJS(AMD) 를 사용해서 개발을 하게 되면 Javascript 관리 및 관심사 분리에 있어서
많은 이점을 얻을 수 있습니다. 하지만, 기존에 개발하던 방식과는 많은 차이가 있기 때문에 불편한 점도 있을 수 있
을거 같은데요. 물론, 해결방법을 몰랐을때에 한해서 입니다. 그 중에서 iframe 과 popup 에서 부모나 오프너로 접
근시 접근하기가 쉽지 않은데요. 해결하는 방법을 적어 봤습니다.

우선 `Require.js (v2.2.0)`, `knockout.js (v3.4.0)` 파일을 `/Js` 폴더 하위에 위치시킵니다. 그리고 나서 
설정을 선언할 파일을 동일한 위치에 생성하고 아래와 같이 작성합니다.

> main.js

```Javascript
require.config({
    baseUrl: '/js',
    paths: {
        'ko3.4.0': 'knockout'
    },
    shim: {
        'ko3.4.0': {
            exports: 'ko'
        }
    },
    waitSeconds: 15
});
```   

팝업을 띄울 메인 Html 파일을 만듭니다.

> index.html

```Html
<!DOCTYPE html>
<html lang=ko>
    <head>
        <title>KO With RequireJS 팝업에서 접근하기</title>
    </head>
    <body>
        <h1>RequireJS Popup Test</h1>
        <button data-bind="click: popup">Popup</button>

        <script src="/js/require.js"></script>
        <script src="/js/main.js"></script>
        <script>
            "use strict";

            require([
                'ko3.4.0'
            ],
            function(ko) {
                var ViewModel = function() {
                    var self = this;

                    self.popup = function() {
                        window.open('Popup.html', 'pop', width=300,height=200');
                    }
                };

                ko.applyBindings(new ViewModel);
            },
            function(err) {
                alert(err);
            });
        </script>
    </body>
</html>
```

팝업창도 만듭니다. 부모창에 접근하는 `OpenerCall` 메서드도 추가 합니다. 부모창에 불리워질 메서드는 `AccessCall`
이란 메서드가 있다고 가정하고 호출하는 코드를 작성합니다.

> Popup.html

```Html
<!DOCTYPE html>
<html lang=ko>
    <head>
        <title>KO With RequireJS 팝업에서 접근하기</title>
    </head>
    <body>
        <h1>RequireJS Opener Test</h1>

        <button>Opner Access</button>

        <script src="/js/require.js"></script>
        <script src="/js/main.js"></script>
        <script>
            "use strict";

            require([
                'ko3.4.0'
            ],
            function(ko) {
                var ViewModel = function() {
                    var self = this;

                    self.OpenerCall = function() {
                        opener.AccessCall();
                    };
                };

                ko.applyBindings(new ViewModel);
            },
            function(err) {
                alert(err);
            });
        </script>
    </body>
</html>    
```

그리고 팝업에서 불리어질 `AccessCall` 메서드를 `index.html` 에 추가합니다.

> index.html 에 `AccessCall`, `self.AccessCall` 메서드 추가

```Html
... 생략
require([    
    ...
],
function(ko) {
    ...
    self.AccessCall = function() {
        alert('OK~~!');
    }
}
    ...
);

function AccessCall() {
    self.AccessCall();
}
```

팝업을 띄워 부모창에 접근이 되는지 확인을 해보면... 안타깝게도 다음과 같은 에러가 발생합니다.

> Error

```Text
SCRIPT5002: Function expected (다르게 표시되기도 합니다.)
```

이 에러를 해결하기 위해서는 `index.html` 에 `self` 를 전역설정 하면 해결됩니다.

> index.html 에 `self` 전역설정

```Html
... 생략
require([    
    ...
],
function(ko) {
    ...
    var self = this;
    // -- 전역설정
    window.self = self;
}
    ...
);
... 생략
```

그리고 `index.html` 에서 새로고침을 하고 다시 한번 팝업창을 띄워 실행해 보면 다음과 같이 정상 작동되는것을 확인
할 수 있습니다.

![그림1](http://i.imgur.com/LA18EJ6.png) 

> index.html 전체 코드

```Html
<!DOCTYPE html>
<html lang=ko>
    <head>
        <title>KO With RequireJS 팝업에서 접근하기</title>
    </head>
    <body>
        <h1>RequireJS Popup Test</h1>
        <button data-bind="click: popup">Popup</button>

        <script src="/js/require.js"></script>
        <script src="/js/main.js"></script>
        <script>
            "use strict";

            require([
                'ko3.4.0'
            ],
            function(ko) {
                var ViewModel = function() {
                    var self = this;

                    // -- 전역설정
                    window.self = self;
                    
                    self.popup = function() {
                        window.open('Popup.html', 'pop', width=300,height=200');
                    }

                    self.AccessCall = function() {
                        alert('OK~~!');
                    }
                };

                ko.applyBindings(new ViewModel);
            },
            function(err) {
                alert(err);
            });

            function AccessCall() {
                self.AccessCall();
            }
        </script>
    </body>
</html>
```

알고나면 아주 간단한 방법인데, 그 알기전까지의 과정은 정말 답답하죠~ ㅎ 초심을 잃지
않기 위해 오늘도 전 삽질 중입니다~

#### 참조
- RequireJS Download : <a href='http://requirejs.org/docs/download.html#rjs' target="_blank">http://requirejs.org/docs/download.html#rjs</a>
- KnockoutJS Download : <a href='http://knockoutjs.com/downloads/index.html' target="_blank">http://knockoutjs.com/downloads/index.html</a>