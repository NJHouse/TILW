## CarouselView 적용해 보기
안녕하세요 NJHouse 입니다.<br/>
예전에 부분 Carousel 이 안되서 많이 고민한 적이 있었습니다. 앱에서 가장 많이 활용되는 부분인데, 이 중요한
기능이 안되면 작업할때 많은 벽에 부딪히겠구나 라고 생각되어서 네이티브로 가야하나 생각할 정도로 저 개인적으로
는 중요한 기능이라고 생각했습니다.
그런데 최근에 NuGet 에 `Xamarin.Forms.CarouselView` 라는 것이 등장하더군요. 앞으로 더욱더 네이티브 기능에
가깝게 접근 및 발전 할 거 같단 생각을 많이 하게됐습니다.
아직 Preview2 버전이긴 합니다만, 곧 릴리즈 될거라 기대해 보면서.. 폰에서 어떻게 보일지 궁금해 예제를 한번
따라해봤습니다.

#### 프로젝트 생성
프로젝트 생성하는 방법은 생략하겠습니다. 저는 **Xamarin.Forms Shared** 프로젝트로 생성했습니다.

#### 모델 구성
**Shared** 프로젝트에 다음과 같이 구성합니다.
1. `Models` 폴더를 생성합니다.
2. Models 폴더 하위에 `CarouselView` 폴더를 생성합니다.

> /Models/CarouselView/Animals.cs 생성

```CSharp
namespace XamarinResolve
{
    public class Zoo
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
}
```

이미지 URL 과 이름을 설정할 간단한 Entity 모델을 구성합니다.

> /Models/CarouselView/AnimalsViewModel.cs 생성

```CSharp
using System.Collections.ObjectModel;

namespace XamarinResolve
{
    public class AnimalsViewModel
    {
        public ObservableCollection<Zoo> Zoos { get; set; }

        public AnimalsViewModel()
        {
            Zoos = new ObservableCollection<Zoo>
            {
                new Zoo 
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                    Name = "Woodland Park Zoo"
                },
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                    Name = "Cleveland Zoo"
                },
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                    Name = "Phoenix Zoo"
                }
            }
        }
    }
}
```
모델과 뷰를 연결해줄 뷰모델을 작성하고 **Carousel** 할 이미지 3개의 데이타를 입력합니다.

> /TCarouselView.xaml 생성

```Xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="XamarinResolve.TCarouselView"
    xmlns:cv="clr-namespace:Xamarin.Forms;assembly=Xamarin.Forms.CarouselView" // 빌드시 주석문은 삭제해 주세요 : CarouselView 의 네임스페이스 설정 cs 파일에 using 문이라고 생각하면 될거 같습니다.
    xmlns:local="clr-namespace:XamarinResolve;assembly=XamarinResolve" // 빌드시 주석문은 삭제해 주세요 : 뷰모델 네임스페이스 설정
    >

    <!-- 뷰모델의 데이타 바인딩 설정 -->
    <ContentPage.BindingContext>
        <local:AnimalsViewModel/>
    </ContentPage.BindingContext>

    <ContentPage.Content>
        <Grid RowSpacing="0">
            
            <Grid.RowDefinitions>
                <RowDefinition Height=".3*"/>
                <RowDefinition Height=".7*"/>
            </Grid.RowDefinitions>

            <cv:CarouselView ItemsSource="{Binding Zoos}" x:Name="CarouselZoos">
                <cv:CarouselView.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="*"/>
                                <RowDefinition Height="Auto"/>
                            </Grid.RowDefinitions>
                            <Image Grid.RowSpan="2" Aspect="AspectFill" Source="{Binding ImageUrl}"/>
                            <StackLayout Grid.Row="1" BackgroundColor="#80000000" Padding="12">
                                <Label TextColor="White" Text="{Binding Name}" FontSize="16" HorizontalOptions="Center" VerticalOptions="CenterAndExpand"/>
                            </StackLayout>
                        </Grid>
                    </DataTemplate>
                </cv:CarouselView.ItemTemplate>
            </cv:CarouselView>

        </Grid>
    </ContentPage.Content>

</ContentPage>
```
xaml 파일을 위와 작성 후 실행을 합니다.

[그림]

그럼 위와 같이 작동 하는것을 확인할 수 있습니다.<br/>
실제 폰에서 해보니 만족할 만한 수준인듯 합니다. 지금 프리뷰2 이니까 릴리즈시에는 더 개선되어 있지 않을까요? 
다른 기능들에 대해서도 좀 더 알아봐야겠습니다.<br/>
읽어 주셔서 감사합니다.

#### 참조

- https://blog.xamarin.com/flip-through-items-with-xamarin-forms-carouselview/ : By James Montemagno
