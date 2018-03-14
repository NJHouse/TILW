## [Shared] Custom Font

안녕하세요. NJHouse 입니다.

사용자 정의 폰트를 어떻게 사용하는지 알아보도록 하겠습니다.

폰트 역시 Style에 종속 되므로 지난 글 <a href="http://myapplication.tistory.com/84" target="_blank">**[Style 정의]**</a> 포스팅을 참조 하시면 도움이 될 것 같습니다.

시작 하기전 폰트를 준비 해야 합니다.

- NanumBarunGothic.ttf
- NanumBarunGothicBold.ttf

전 이렇게 준비 했습니다.

##### Android

![그림](https://s10.postimg.org/odynultgp/xfncr_004_001.png)

Android 프로젝트 하위에 **Assets** 폴더에 폰트를 복사해 넣습니다.

##### iOS

![그림](https://s10.postimg.org/wph39t8q1/xfncr_004_002.png)

iOS 프로젝트 하위에 있는 **Resources** 폴더에 폰트 파일을 복사해 넣습니다.

![그림](https://s10.postimg.org/5l9h51rtl/xfncr_004_003.png)

그리고 프로젝트 Root 에서 오른쪽 마우스 클릭하면 나오는 팝업메뉴 중 **파일 탐색기에서 폴더 열기(X)**

를 선택해 파일 탐색기를 엽니다.

![그림](https://s10.postimg.org/4x0mm2b3d/xfncr_004_004.png)

**Info.plist** 라는 파일의 코드를 수정할 수 있게 다른 에디터로 열어서 아래와 같이 코드를 추가 합니다.

>Info.plist

```Xml
    ...
    <key>UIAppFonts</key>
    <array>
        <string>NanumBarunGothicBold.ttf</string>
        <string>NanumBarunGothic.ttf</string>
    </array>
```

Shared 프로젝트 메인 페이지에서 폰트 예제를 확인 할 수 있는 버튼과 예제 페이지를 만들어 보겠습니다.


>Shared] /MainPage.xaml

```Xml
...
            <Button
                Text="Custom Font"
                Clicked="Btn_FontView_Clicked"
                />
...                
```

>Shared] /MainPage.xaml.cs

```CSharp
...
        private async void Btn_FontView_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new CustomFont());
        }
...
```

![그림](https://s10.postimg.org/n7lxnfzjt/xfncr_004_005.png)

Views 폴더 하위에 **customFont.xaml** 과 **CustomFont.xaml.cs** 파일을 생성 합니다. 기본 폰트를 보여줄 버튼을

생성합니다.

>Shared] /Views/CustomFont.xaml

```Xml
...
        <Button
            Text="Default Font"
            BackgroundColor="Orange"
            TextColor="White"
            />
...
```

##### Android

![그림](https://s10.postimg.org/amlgjytqx/xfncr_004_006.png)

##### iOS

![그림](https://s10.postimg.org/6q84o0qrt/xfncr_004_007.png)

폰트를 사용할 수 있도록 명시적 선언을 해보겠습니다.

![그림](https://s10.postimg.org/xe9oxpibd/xfncr_004_008.png)

Shared 프로젝트 Styles 폴더 밑에 **Fonts.xaml** 과 **Fonts.xaml.cs** 파일을 생성하고 아래 코드로 

수정을 합니다.

>Shared] /Styles/Fonts.xaml

```Xml
<ResourceDictionary ...
    />

    <OnPlatform x:TypeArguments="x:String" x:Key="NaNumBarunGothic">
        <On Platform="iOS" Value="NanumBarunGothic" />
        <On Platform="Android" Value="NanumBarunGothic.ttf#NanumBarunGothic" />
    </OnPlatform>

    <OnPlatform x:TypeArguments="x:String" x:Key="NaNumBarunGothicBold">
        <On Platform="iOS" Value="NanumBarunGothicBold" />
        <On Platform="Android" Value="NanumBarunGothicBold.ttf#NanumBarunGothic" />
    </OnPlatform>

</ResourceDictionary>
```

>Shared] /Styles/Fonts.xaml.cs

```CSharp
...
    public partial class Fonts : ResourceDictionary
    {
        ...
    }
...
```

App.xaml 에 명시적 선언을 하여 Global StaticResource 로 사용 가능하게 설정 하겠습니다.

>Shared] /App.xaml
```Xml
...
            <ResourceDictionary.MergedDictionaries>
                <styles:Buttons />
                <styles:Fonts />
            </ResourceDictionary.MergedDictionaries>
...
```

이제 버튼을 추가해 폰트가 잘 적용 되는지 살펴보겠습니다. 폰트 비교가 잘 되게 같은 글로 변경해 보고 배경색

도 초록색으로 바꿔 보겠습니다.

>Shared] /Views/CustomFont.xaml

```Xml
...
        <Button
            Text="자마린 폼즈(Default)"            
            BackgroundColor="Green"
             TextColor="White"
                />

        <Button
            Text="자마린 폼즈(나눔바른고딕)"            
            BackgroundColor="Green"
            TextColor="White"
            FontFamily="{StaticResource NaNumBarunGothic}"
                />

        <Button 
            Text="어서와 자마린 폼즈(나눔바른고딕볼드)"
            BackgroundColor="Green"
            TextColor="White"
            FontFamily="{StaticResource NaNumBarunGothicBold}"
                />
...
```

##### Android

![그림](https://s10.postimg.org/6ff0ucfuh/xfncr_004_009.png)

##### iOS

![그림](https://s10.postimg.org/u6eecjns9/xfncr_004_010.png)

좀 티가 많이 나는 폰트로 할 것을 그랬나요?? 구분이 잘 안되네요.... 자세히 보시면 'ㅈ' 자의 모양이

다르다는 걸 알 수 있을겁니다. 볼드는 확연히 티나구요. 

그럼 그만 마치겠습니다.

