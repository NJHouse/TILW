## [생각없이 앱 개발하기] 데이타 공수 & 메인 UI 
안녕하세요.
NJHouse 입니다. 이번에는 메인 UI 설계 및 병원 및 약국 데이타를 어떻게 요청하는지 알아보겠습니다.
우선 UI설계를 하려면, 어떤 데이타를 보여줄 수 있는지, 어떤 기능을 탑재할지를 결정해야겠죠. 그럼 우선
데이타를 어디서 가져오는지 알아보겠습니다.

#### 공공데이타
최근 들어서 데이타 공유가 활발히 이뤄지고 있습니다. 각 지자체나 대형 포털사 등에서 REST API(Open API)를 통해서
많은 데이타를 제공하고 있습니다. 그 중에서 전 `공공데이터포털(https://www.data.go.kr)` 사이트를 통해 제가 필요로
하는 데이타를 신청해 보겠습니다.

#### 회원가입
우선 데이타를 신청하려면, 사이트에 회원 가입이 되어 있어야 합니다. (회원가입 부분은 생략합니다.)

#### Web API 요청 등록
우선 `https://www.data.go.kr` 사이트에 접속합니다. 로그인을 해 놓으면 편한것이 요청하고 싶은 데이타가 
있다면 바로 요청 할 수 있습니다. 비로그인시에는 로그인 페이지로 갔다가 다시 검색해야 할 수도 있습니다. (추가로 인터넷익스플로러
사용을 권장합니다. 데이타 요청시 엑티브 엑스 요청이 있을 수 있습니다.)

![그림1](https://s10.postimg.org/cvgm83pux/forhealth_mainui_002_02.png)

메인 페이지 검색 폼에서 `전국 병의원`을 입력 후 검색 버튼을 클릭합니다.

![그림2](https://s22.postimg.org/8mrlm226p/forhealth_mainui_002_03.png)

검색 후 **오픈API** 탭을 선택하면 `전국 병.의원 찾기 서비스` 라고 검색된걸 볼 수 있습니다. 제목을 클릭 합니다.

![그림3](https://s10.postimg.org/850betitl/forhealth_mainui_002_04.png)

상세 페이지로 들어가서 **상세정보**를 클릭합니다.

![그림4](https://s9.postimg.org/6gg7vgba7/forhealth_mainui_002_05.png)

위 그림과 같이 `병.의원 목록정보 조회`, `병.의원 위치정보 조회`, `병.의원별 기본정보 조회` 이렇게 세 가지 
정보를 제공 하는걸 알 수 있습니다. 상세 정보를 닫습니다.

![그림5](https://s15.postimg.org/4r7cww6m3/forhealth_mainui_002_06.png)

이번엔 **활용신청**을 클릭합니다.

![그림6](https://s13.postimg.org/ghg3oye1z/forhealth_mainui_002_07.png)

우선은 개발계정 신청입니다. 개발계정 신청은 1일 트개픽이 1000으로 제한됩니다. 추후 앱개발이 완료되면 운영계정을
신청하면 10,000건으로 확대됩니다.<br/>

**시스템유형 선택** : 일반<br/>
**활용정보** : 앱개발(모바일,솔루션등)<br/>
**상세기능정보** : 전체선택<br/>
**라이센스표시** : 동의<br/>  
후 **신청** 버튼을 클릭합니다.

![그림7](https://s15.postimg.org/qaiqg4h5n/forhealth_mainui_002_08.png)

위와 같은 메세지가 보여지면서 바로 승인처리가 됩니다. (운영계정은 몇일간의 승인 절차가 이뤄집니다.)<br/>

승인은 되지만, 데이타는 바로 보이지 않을겁니다. 24시간 후 에 확인하면 데이타가 잘 보여지는 걸 확인 할 수 있습니다.

약국 정보 데이타도 위와 같은 방법으로 진행하면 됩니다. 과정은 생략하겠습니다.

####UI 설계

일단 기능도 심플할 계획이니 간단히 병원, 약국을 지역별로 조회만 하는 화면으로 설계를 해보겠습니다.

![그림8](https://s16.postimg.org/yv7gtewrp/forhealth_mainui_002_09.png)

랜딩페이지는 위 그림과 같이 3단으로 구성하고 중앙에 조회 할 수 있는 버튼을 두어 그 버튼을 터치 하면 우측 
그림 처럼 조회, 검색 버튼을 노출하는 페이지 입니다. 그리고 나서 검색 리스트 페이지로 가면 되겠지요.

#### Layout 코딩
`ForHealthFormsShared` 프로젝트에서 **Main.xaml**과 **Main.xaml.cs** 파일을 생성합니다. 그리고 **Main.xaml**
파일에 다음과 같이 작성합니다.

>Main.xaml - 3단 레이아웃 작성

```Xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage 
    xmlns="http://xamarin.com/schemas/2014/forms" 
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" 
    x:Class="ForHealthFormsShared.Main2">

    <!-- [1] ContentPage.Content 를 RelativeLayout 으로 변경하고 배경색을 White 로 설정합니다. -->
    <RelativeLayout BackgroundColor="White">
        <!-- [2] 부모레이아웃 크기와 일치하는 Grid 를 만들어 줍니다. --> 
        <Grid 
            RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=1}"
            RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=1}">

            <!-- [3] RowDefinitions 를 통해 3:1:3 비율의 영역을 나눠 줍니다. -->
            <Grid.RowDefinitions>
                <RowDefinition Height="3*"/>
                <RowDefinition Height="1*"/>
                <RowDefinition Height="3*"/>
            </Grid.RowDefinitions>

            <!-- [4] 각 영역을 StackLayout 으로 채우고 영역 구분을 위해 BackgroundColor 를 지정해 봤습니다. -->
            <StackLayout Grid.Row="0" BackgroundColor="#93BA54">
            </StackLayout>

            <StackLayout Grid.Row="1">
            </StackLayout>

            <StackLayout Grid.Row="2" BackgroundColor="#F59445">
            </StackLayout>

        </Grid>
    </RelativeLayout>
</ContentPage>
```

xaml 파일 내에 주석으로 설명을 붙였습니다. **App.xaml.cs** 파일을 수정해 로딩 후 **Main.xaml** 페이지가 보이도록
수정을 하겠습니다.

> App.xaml.cs - 랜딩 페이지 지정하기

```CSharp
public partial class App : Application
{
    public App()
    {
        MainPage = new Main();    
    }
    ... 생략
}
```

중간 저장을 하고 실행을 해보겠습니다.

![그림9](https://s16.postimg.org/5yz9au81x/forhealth_mainui_002_10.png)

그럼 위와 같이 3:1:3 비율로 잘 나눠져 있는걸 확인하실 수 있습니다.<br/>

그럼 이제 상단 하단 텍스트 중간에 버튼을 넣어 보겠습니다.

>Main.xaml - 각 영역에 컨텐츠 넣기

```Xml
... 생략
<!-- [1] 상단에 텍스트 삽입 -->
<StackLayout Grid.Row="0" BackgroundColor="#93BA54">
    <Label  Text="병원? 어디있니!" VerticalOptions="CenterAndExpand"
        HorizontalOptions="Center" FontSize="30" TextColor="White" />
</StackLayout>

<!-- [3] 중앙에 버튼을 삽이하기 위한 작업을 합니다.-->
<StackLayout Grid.Row="1">
    <!-- [3-1] 부모 크기와 같은 Grid를 만듭니다. -->
    <Grid VerticalOptions="FillAndExpand" HorizontalOptions="FillAndExpand">
        <!-- [3-2] 그리고 버튼이 두개니까 1:1 비율로 영역을 나눠줍니다. -->
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="1*"/>
            <ColumnDefinition Width="1*"/>
        </Grid.ColumnDefinitions>

        <!-- [3-3] 버튼을 만듭니다. 컬러, 마진을 설정하고 각 버튼에 이름을 부여합니다. -->
        <Button Grid.Column="0"
            Text="병원조회" 
            BackgroundColor="#93BA54"
            Margin="5,0,0,0"
            x:Name="SearchBtnHospital"/>
        <Button Grid.Column="1"
            Text="약국조회"
            BackgroundColor="#F59445"
            Margin="0,0,5,0"
            x:Name="SearchBtnDrugstore"/>

    </Grid>    
</StackLayout>

<!-- [2] 하단에 텍스트 삽입 -->
<StackLayout Grid.Row="2" BackgroundColor="#F59445">
    <Label Grid.Row="2" Text="약국? 어디있니!" VerticalOptions="CenterAndExpand"
        HorizontalOptions="Center" FontSize="30" TextColor="White" />
</StackLayout>
... 생략
``` 

 자 한번 어떻게 보이는지 볼까요? 

 ![그림10](https://s10.postimg.org/52mnjp9bt/forhealth_mainui_002_11.png)

 짧게 나마 기획했던 모양과 거의 일치하네요. 디자인도 개발자 치곤 그럭저럭 봐줄만 하네요.<br/>

 `병원조회`, `약국조회` 각각의 버튼을 누르면 상단에서 검색 버튼들이 내려오고, 하단에서 검색 버튼들이 
 올라오고 다시한번 누르면 제자리로 돌아가는 약간의 애니메이션이 추가된 기능을 구현해 보겠습니다.

 우선 `병원조회` 버튼을 눌렀을때 상단에서 내려올 검색 버튼들을 만들어 보죠.

 >Main.xaml - 병원조회 검색 버튼만들기

 ```Xml
 ... 생략
        <StackLayout Grid.Row="2" BackgroundColor="#F59445">
            <Label Grid.Row="2" Text="약국? 어디있니!" VerticalOptions="CenterAndExpand"
                HorizontalOptions="Center" FontSize="30" TextColor="White" />
        </StackLayout>
    </Grid>

    <StackLayout x:Name="SearchBtnsTop" Orientation="Vertical"
        RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=0.5}"
        RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0.25}"
        RelativeLayout.XConstraint= "{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=0.25}"
        RelativeLayout.YConstraint= "{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=-0.28}">

        <Button Text="시도" BackgroundColor="White" BorderColor="#F59445" BorderWidth="2" TextColor="Black" />
        <Button Text="시구군" BackgroundColor="White" BorderColor="#F59445" BorderWidth="2" TextColor="Black"/>
        <Button Text="검색" BackgroundColor="White" BorderColor="#F59445" BorderWidth="2" TextColor="Black"/>
    </StackLayout>

</RelativeLayout>
... 생략
```

**SearchBtnsTop** 이란 이름을 갖는 StackLayout 을 만들어 그 안에 세개의 버튼이 세로로 나열되게 설정합니다. (RelativeLayout
위치 사이즈 설정을 나중에 다른 글로 한번 다시 언급해 보도록 하겠습니다.) 이렇게 만든 검색 버튼 영역을 `병원조회` 버튼을 누르면
아래로 내려오는 것을 구현해 보죠.

>Main.xaml.cs - 병원조회 검색 버튼 구현

```CSharp
... 생략
public Main() {
    InitializeComponent ();

    // -- 이 속성은 검색 버튼들이 어떤 상태인지를 파악 하기 위함 입니다.
    bool isClickHospital = false;

    SearchBtnHospital.Clicked += async (sender, e) =>
    {
        if (!isClickHospital)
        {
            // -- (비동기)위치변경 애니메이션으로 검색 버튼을 노출합니다.
            await SearchBtnsTop.TranslateTo(0, 200, 700, Easing.SinIn);
            isClickHospital = true;
        } else {
            // -- (비동기)위치변경 애니메이션으로 검색 버튼을 숨깁니다.
            await SearchBtnsTop.TranslateTo(0, -1, 700, Easing.SinIn);
            isClickHospital = false;
        }
    };
}
... 생략
```

입력을 하고 나서 결과를 보면 아래 그림과 같습니다.

![그림11](https://s9.postimg.org/8w8222c6n/forhealth_mainui_002_12.gif)

`Genymotion` 으로 실행한 것인데 내려왔다 올라갈때 잔상을 남기고 가네요. 잘 작동 하는걸 확인할 수 있습니다.
그럼 `약국조회` 버튼 기능도 만들어 볼까요.

>Main.xaml - 약국조회 검색 버튼만들기

```Xml
... 생략
<StackLayout x:Name="SearchBtnBottom" Orientation="Vertical"
        RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=0.5}"
        RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0.25}"
        RelativeLayout.XConstraint= "{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=0.25}"
        RelativeLayout.YConstraint= "{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=1}">

    <Button Text="시도" BackgroundColor="White" BorderColor="#93BA54" BorderWidth="2" TextColor="Black" />
    <Button Text="시구군" BackgroundColor="White" BorderColor="#93BA54" BorderWidth="2" TextColor="Black"/>
    <Button Text="검색" BackgroundColor="White" BorderColor="#93BA54" BorderWidth="2" TextColor="Black"/>
</StackLayout>
... 생략
```

`병원조회` 검색 버튼과 동일하고 컬러와 위치만 바꼈습니다. `약국조회` 버튼을 터치했을때 검색버튼이 움직이는 것을 구현해 보겠습니다.
상단 버튼과 위치 값만 다르고 동일합니다.

>Main.xaml.cs - 약국조회 검색 버튼 구현

```CSharp
... 생략
bool isClickHospital = false;
// -- 약국 검색 버튼의 사태를 파악하기 위한 속성값입니다.
bool isClickDrugStore = false;
... 생략 ...

SearchBtnDrugstore.Clicked += async (sender, e) =>
{
    if (!isClickDrugStore)
    {
        await SearchBtnBottom.TranslateTo(0, -200, 700, Easing.SinIn);
        isClickDrugStore = true;
    }
    else {
        await SearchBtnBottom.TranslateTo(0, 1, 700, Easing.SinIn);
        isClickDrugStore = false;
    }
};
```

실행해 두 버튼이 모두 잘 작동하는지 확인해 보죠.

![그림12](https://s15.postimg.org/sg1trgtjf/forhealth_mainui_002_13.gif)

잘 작동하는 것이 확인 되는군요. 버튼을 빠른 속도로 터치하면 내려가지도 올라가지도 않는 상태가 되는데요. 이건 
따로 처리를 해줘야 합니다. 애니메이션이 끝났을때 콜백을 통해 버튼을 제어하는 등의 방법을 적용하면 될거 같네요.

그럼 이번은 여기까지 하면 될거 같습니다. 여기까지 읽어 주셔서 감사합니다.

