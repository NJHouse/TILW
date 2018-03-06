## [Shared] Style 정의

안녕하세요.

NJHouse 입니다.

Style 정의하는 방법에 대해서 알아보겠습니다.

버튼에 배경색 과 글씨의 색을 변경하는 아주 간단한 예제를 들어 설명하겠습니다.

그전에 **MainPage.xaml** 에 **Style**정의 페이지로 이동할 버튼을 만들면서 시작하겠습니다.

>MainPage.xaml

```Xml
<ContentPage ...중략>

    <ScrollView VerticalOption="FillAndExpand">
        <StackLayout
            HorizontalOptions="FillAndExpand"
            VerticalOptions="CenterAndExpand">

            <Button
                Text="Style 정의"
                Clicked="Btn_StyleDefine_Clicked" />

        </StackLayout>
    </ScrollView>

</ContentPage>
```

![그림1](https://s10.postimg.org/8dhx6dmqh/xfncr_003_001.png)

Shared 프로젝트 하위에 **Views** 라는 폴더를 만들고, 그 하위에 **StyleDefine.xaml,cs** 파일을 생성합니다.

![그림2](https://s10.postimg.org/fw12eqqvd/xfncr_003_002.png)

**MainPage.xaml.cs** 에 버튼을 눌렀을때의 이벤트 **Btn_StyleDefine_Clicked**를 작성해 이동이 가능 하도록 합니다.

>MainPage.xaml.cs

```CSharp
... 중략
    private async void Btn_StyleDefine_Clicked(object sender, EventArgs e) {
        await Navigation.PushAsync(new StyleDefine());
    }
... 중략
```

이제 Style을 정의하고 사용할 페이지에 코드를 작성해 보겠습니다.

우선 **Button** 컨트롤에 직접 Style을 정의해 보죠.

>/Views/StyleDefine.xaml

```Xml
<ContentPage...중략>

    <StackLayout HorizontalOptions="FillAndExpand"
                 VerticalOptions="CenterAndExpand"
                 >

        <!-- [1] Button에 직접 Style 정의 -->
        <Button Text="Default Style"
                BackGroundColor="Orange"
                TextColor="White"
                FontAttribute="Bold" />

    </StackLayout>

</ContentPage>
```

![그림3](https://s10.postimg.org/tsdw4hmtl/xfncr_003_003.png)

이제 Style을 명시적으로 선언해 볼까요? 명시적 선언은 여러개의 컨트롤에 동일한 Style을 적용해야 할

상황에 유용합니다.

노란색 바탕의 버튼의 Style을 명시적으로 적용해 보겠습니다.

>/Views/StyleDefine.xaml

```Xml
<ContentPage...중략>

    <!-- [2] 명시적 Style 정의 -->
    <ContentPage.Resources>
        <ResourceDictionary>
            <Style x:Key="BtnExplicitStyle" TargetType="Button">
                <Setter Property="BackgroundColor" Value="Yellow" />
                <Setter Property="TextColor" Value="Black" />
                <Setter Property="FontAttributes" Value="Bold" />
            </Style>            
        </ResourceDictionary>
    </ContentPage.Resources>

    <StackLayout HorizontalOptions="FillAndExpand"
                 VerticalOptions="CenterAndExpand">

        <!-- [1] Button에 직접 Style 정의 -->
        <Button Text="Default Style"
                BackGroundColor="Orange"
                TextColor="White"
                FontAttribute="Bold" />

        <!-- [2] -->
        <Button
            Text="Explicit Style"
            Style="{StaticResource BtnExplicitStyle}" />
    </StackLayout>

</ContentPage>
```

![그림4](https://s10.postimg.org/irxwqmqc9/xfncr_003_004.png)

다른 페이지에서도 같은 Style이 필요할때가 있을 수 있는데요. 이 때는 **App.xaml** 에 명시적으로

선언을 하여 사용 할 수 있습니다. **Global Style** 라고 합니다.

초록색 바탕의 버튼 Style을 **App.xaml** 에 선언해 보겠습니다.

>App.xaml

```Xml
<Application ...중략>
    <Application.Resources>

        <ResourceDictionary>

            <!-- [3] Global Style 선언 -->
            <Style x:Key="BtnGlobalStyle" TargetType="Button">
                <Setter Property="BackgroundColor" Value="Green" />
                <Setter Property="TextColor" Value="White" />
                <Setter Property="FontAttributes" Value="Bold" />
            </Style>
        </ResourceDictionary>

	</Application.Resources>
</Application>
```

>/Views/StyleDefine.xaml

```Xml
<ContentPage...중략>

    <!-- [2] 명시적 Style 정의 -->
    <ContentPage.Resources>
        <ResourceDictionary>
            <Style x:Key="BtnExplicitStyle" TargetType="Button">
                <Setter Property="BackgroundColor" Value="Yellow" />
                <Setter Property="TextColor" Value="Black" />
                <Setter Property="FontAttributes" Value="Bold" />
            </Style>            
        </ResourceDictionary>
    </ContentPage.Resources>

    <StackLayout HorizontalOptions="FillAndExpand"
                 VerticalOptions="CenterAndExpand">

        <!-- [1] Button에 직접 Style 정의 -->
        <Button Text="Default Style"
                BackGroundColor="Orange"
                TextColor="White"
                FontAttribute="Bold" />

        <!-- [2] -->
        <Button
            Text="Explicit Style"
            Style="{StaticResource BtnExplicitStyle}" />

        <!-- [3] -->
        <Button
            Text="Global Style"
            Style="{StaticResource BtnGlobalStyle}"
            />
    </StackLayout>

</ContentPage>
```

![그림](https://s10.postimg.org/ohiqoutnt/xfncr_003_005.png)

잘 적용 되고 있네요. 여기서 생각해 볼 것이 실제 프로젝트에선 수 많은 Style이 필요합니다. 

그런데 그 수많은 Style을 **App.xml** 에 선언을 한다고 생각하면 코드 라인이 엄청 길어지겠지요.

코드 라인이 많다는 건 상황에 따라 다를 수 있겠지만, 대부분 직관적이지 않다라고 볼 수 있을 것 같네요.

카테고리 별 파일로 따로 정의 해 놓으면 관리가 쉬울 것 같습니다. 마지막으로 파일을 분류해 정의를 하고

마치겠습니다.

![그림](https://s10.postimg.org/m1gxarynt/xfncr_003_006.png)

우선 **Shared** 프로젝트에서 **Styles** 폴더를 만들고 그 하위에 **Buttons.xaml**과 **Butons.xaml.cs** 파일을 

생성 합니다. 그리고 아래와 같이 작성 합니다.

>/Styles/Buttons.xaml

```Xml
<?xml version="1.0" encoding="utf-8" ?>
<ResourceDictionary xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="XFNCResolve.Share.Styles.Buttons">

    <!-- [4] Behind Style -->
    <Style x:Key="BtnBehindStyle" TargetType="Button">
        <Setter Property="BackgroundColor" Value="Blue" />
        <Setter Property="TextColor" Value="White" />
        <Setter Property="FontAttributes" Value="Bold" />
    </Style>
    
</ResourceDictionary>
```

>/Styles/Buttons.xaml.cs

```CSharp
...중략
    public partial class Buttons : ResourceDictionary
    {
        public Buttons ()
        {
            InitializeComponent ();
        }
    }
```

>App.xml

```Xml
<Application ...중략
    xmlns:styls="clr-namespace:XFNCResolve.Share.Styles">

    <Application.Resources>

        <ResourceDictionary>
            ... 중략

            <!-- [4] -->
            <ResourceDictionary.MergedDictionaries>
                <styls:Buttons />
            </ResourceDictionary.MergedDictionaries>

        </ResourceDictionary>
    </Application.Resources>
</Application>    
```
>/Views/StyleDefine.xaml

```Xml
<ContentPage...중략>

    <!-- [2] 명시적 Style 정의 -->
    <ContentPage.Resources>
        <ResourceDictionary>
            <Style x:Key="BtnExplicitStyle" TargetType="Button">
                <Setter Property="BackgroundColor" Value="Yellow" />
                <Setter Property="TextColor" Value="Black" />
                <Setter Property="FontAttributes" Value="Bold" />
            </Style>            
        </ResourceDictionary>
    </ContentPage.Resources>

    <StackLayout HorizontalOptions="FillAndExpand"
                 VerticalOptions="CenterAndExpand">

        <!-- [1] Button에 직접 Style 정의 -->
        <Button Text="Default Style"
                BackGroundColor="Orange"
                TextColor="White"
                FontAttribute="Bold" />

        <!-- [2] -->
        <Button
            Text="Explicit Style"
            Style="{StaticResource BtnExplicitStyle}" />

        <!-- [3] -->
        <Button
            Text="Global Style"
            Style="{StaticResource BtnGlobalStyle}"
            />

        <!-- [4] -->
        <Button
            Text="Behind Style"
            Style="{StaticResource BtnBehindStyle}"
            />
    </StackLayout>

</ContentPage>
```

![그림](https://s10.postimg.org/8acg8m761/xfncr_003_008.png)