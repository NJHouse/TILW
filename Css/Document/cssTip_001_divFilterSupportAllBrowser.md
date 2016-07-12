## 반투명 Div 만들기

백 그라운드에서 데이타 처리라던지 되고 있을때, 사용자에게 뭔가 하고 있다는 의미로 프로그래스 바(링) 등을<br/>
보여 줍니다.<br/> 
지금까진 IE 에서만 반 투명 이미지가 보여지면 됐었는데 앞으로는 Css 를 만들때 대부분의 브라우져에서 같은 동작<br/>
을 하게끔 해야 하는 시대가 왔네요. 좋은 시절 다 갔죠 ^^; 신경쓸 일이 많아졌으니까요. 사용자의 눈도 높아졌기<br/>
때문에 간과하면 안될듯 합니다.

>IE에만 적용했던 Div 반투명 Css (with KO)
```HTML
<div data-bind="visible: activeIndicate">
    <div id="dvCurtain" style="position:absolute; width:100%; height:100%; left:0; top:0; z-index: 990; background:#000; filter: alpha(opacity=50); zoom: 1; display:block; " >
        <div style="position:relative;width:80px;margin:0 auto;margin-top:250px;z-index: 991;"><img style="width:80px" src="[프로그래스바(링) 이미지]" /></div>
    </div>
</div>
```

위와 같이 `...background:#000; filter: alpha(opacity=50); zoom: 1;...` 하면 IE 에서는 문제없이 반 투명의<br/>
오버레이가 보여지며 그 위에 프로그래스바(링)이 돌아가는것을 볼 수 있습니다. 그러나... 크롬 및 엣지에서는 검은색의<br/>
백경위에 프로그래스바(링)이 돌아가게 됩니다.

>많은 브라으저에서 반투명 (with KO)
```HTML
<div data-bind="visible: activeIndicate">
    <div id="dvCurtain" style="position:absolute; width:100%; height:100%; left:0; top:0; z-index: 990; background:#000; opacity: 0.5; filter: alpha(opacity=50) !important; zoom: 1; display:block; " >
        <div style="position:relative;width:80px;margin:0 auto;margin-top:250px;z-index: 991;"><img style="width:80px" src="[프로그래스바(링) 이미지]" /></div>
    </div>
</div>
``` 

위와 같이 하게 되면 크롬, 엣지 브라우저에서도 반 투명한 오버레이 위에 있는 프로그래스바(링)을 볼 수 있습니다.