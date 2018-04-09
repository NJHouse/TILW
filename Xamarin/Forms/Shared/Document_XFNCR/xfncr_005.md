## [Shared] Properties

안녕하세요. NJHouse 입니다.

데이타를 로컬 저장소에 저장을 하는 방법을 알아보겠습니다. 일반적으로 로컬 저장은 

**sqlite** 나 **Realms** 를 많이 이용 할 거 같은데요 오늘은 Xamarin.forms 에 기본

내장된 **Properties** 를 이용해 간단한 데이타를 저장해 보겠습니다. 설정 데이타를

저장한다고 생각하면 될 것 같네요.

<br/>

#### 뷰 페이지 만들기 ####
---

예제를 만들기 위한 뷰 페이지를 생성합니다.

Shared 프로젝트 > Views 하위에 아래 두 파일을 생성합니다.
- PropertiesView.xaml
- PropertiesView.Xaml.cs

![그림1](https://s9.postimg.org/x2ui94vz3/xfncr_005_001.png)

<br/>

#### 메인에 뷰 페이지로 이동할 버튼 만들기 ####
---
MainPage.xml 에서 *PropertiesView.xml* 페이지로 이동할 버튼과 클릭 이벤트를 만들어 봅니다.

>Shared] /MainPage.xaml

```Xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage ...>

    ...

        <Button
            Text="Properties 로컬 저장"
            Clicked="Btn_PropertiesView_Clicked"
            />
    ...

</ContentPage>
```

그리고 MainPage.xaml.cs 에서 네비게이션 처리를 합니다.

>Shared] /MainPage.xaml.cs

```CSharp
...
        private async void Btn_PropertiesView_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PropertiesView());
        }
...
```

![그림2](https://s9.postimg.org/4371j5ugf/xfncr_005_003.gif)

<br/>
 
 #### 설정 스위치 버튼 예제 만들기 ####
 ---

*PropertiesView.xaml* 페이지에 세가지 셋팅을 한다는 가정하에 *세팅 A*, *세팅 B*, *세팅 C* 

라는 *Switch* 버튼을 만듭니다.

>Shared] /Views/PropertiesView.xaml

```Xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage ...>
    <ContentPage.Content>

        <StackLayout Orientation="Vertical">

            <StackLayout Orientation="Horizontal"
                         VerticalOptions="CenterAndExpand"
                         HorizontalOptions="CenterAndExpand">
                <Label Text="세팅 A" VerticalOptions="CenterAndExpand" />
                <Switch
                    x:Name="SETA"
                    />
            </StackLayout>

            <StackLayout Orientation="Horizontal"
                         VerticalOptions="CenterAndExpand"
                         HorizontalOptions="CenterAndExpand">
                <Label Text="세팅 B" VerticalOptions="CenterAndExpand" />
                <Switch
                    x:Name="SETB"
                    />
            </StackLayout>

            <StackLayout Orientation="Horizontal"
                         VerticalOptions="CenterAndExpand"
                         HorizontalOptions="CenterAndExpand">
                <Label Text="세팅 C" VerticalOptions="CenterAndExpand" />
                <Switch
                    x:Name="SETC"
                    />
            </StackLayout>

        </StackLayout>
        
    </ContentPage.Content>
</ContentPage>
```

![그림](https://s9.postimg.org/4p0ltdhkv/xfncr_005_004.gif)

<br/>

#### ViewModel 만들기 ####

각 Switch 에 바인딩될 값과 그 값이 변경 되었을때 저장 기능을 가진 ViewModel 을 만듭니다.

>Shared] /Models/PropertiesVModel.cs

```CSharp
using System.ComponentModel;
using Xamarin.Forms;

namespace XFNCResolve.Share.Models
{
    public class PropertiesVModel: INotifyPropertyChanged
    {
        bool isSetA = false;
        bool isSetB = false;
        bool isSetC = false;

        public bool IsSetA
        {
            get { return isSetA; }
            set
            {
                isSetA = value;
                OnPropertyChanged("IsSetA");
                SetProperties("SETA", value);
            }
        }

        public bool IsSetB
        {
            get { return isSetB; }
            set
            {
                isSetB = value;
                OnPropertyChanged("IsSetB");
                SetProperties("SETB", value);
            }
        }

        public bool IsSetC
        {
            get { return isSetC; }
            set
            {
                isSetC = value;
                OnPropertyChanged("IsSetC");
                SetProperties("SETC", value);
            }
        }

        void SetProperties(string pName, bool value)
        {
            Application.Current.Properties.Remove(pName);
            Application.Current.Properties.Add(pName, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

```

Switch 버튼의 실제 상태 값을 담을 멤버 변수 *isSetA*, *isSetB*, *isSetC* 와 Switch 버튼의 상태

변경 값을 멤버 변수에 담고 변경처리를 위한 프로퍼티 *IsSetA*, *IsSetB*, *IsSetC* 가 있습니다.

그리고 *Properties* 를 이용해 값을 저장할 *SetProperties* 비 반환형 메소드가 있습니다.

<br/>

#### Properties 값 설정
---

*PropertiesView.xaml.cs* 에서 *Properties* 의 값의 유무를 따져 있으면 저장된 값에서 가져오고,

그렇지 않으면 *false* 값을 앞에서 만든 ViewModel 의 프로퍼티에 설정한다. 그리고 *BidingContext*

에 ViewModel 을 연결(? 이란 표현이 맞을까) 합니다.

>Shared] /Views/PropertiesView.xaml.cs

```CSharp
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFNCResolve.Share.Models;

namespace XFNCResolve.Share.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertiesView : ContentPage    
    {
        public PropertiesView ()
        {
            InitializeComponent ();

            Title = "Properties";

            PropertiesVModel propertiesVModel = new PropertiesVModel();

            var acProperties = Application.Current.Properties;

            bool setA = false;
            bool setB = false;
            bool setC = false;

            setA = (bool)(acProperties.ContainsKey("SETA") ? acProperties["SETA"] : setA);
            setB = (bool)(acProperties.ContainsKey("SETB") ? acProperties["SETB"] : setB);
            setC = (bool)(acProperties.ContainsKey("SETC") ? acProperties["SETC"] : setC);

            propertiesVModel.IsSetA = setA;
            propertiesVModel.IsSetB = setB;
            propertiesVModel.IsSetC = setC;

            BindingContext = propertiesVModel;
        }
    }
}
```

#### 프로퍼티 바인딩 설정 ####
---

*PropertiesView.xaml* 내에 있는 각 *Switch* 컨트롤러에 *IsToggled* 프로퍼티에 ViewModel 의

*IsSetA*,*IsSetB*,*IsSetC* 바인딩을 설정합니다.

>Shared] /Views/PropertiesView.xaml

```Xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage ...>
    <ContentPage.Content>

        <StackLayout Orientation="Vertical">

            ...
                <Switch
                    x:Name="SETA"
                    IsToggled="{Binding IsSetA}"
                    />
            ...

            ...
                <Switch
                    x:Name="SETB"
                    IsToggled="{Binding IsSetB}"
                    />
            ...

            ...
                <Switch
                    x:Name="SETC"
                    IsToggled="{Binding IsSetC}"
                    />
            ...

        </StackLayout>
        
    </ContentPage.Content>
</ContentPage>
```
<br/>

#### Android 실행 ####
---

![그림](https://s9.postimg.org/sn13ue3jj/xfncr_005_005.gif)

<br/>

#### iOS 실행 ####

![그림](https://s9.postimg.org/nscgszqwf/xfncr_005_006.gif)