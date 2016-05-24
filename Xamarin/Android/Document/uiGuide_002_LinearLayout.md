##LinearLayout

LinearLayout 은 하위 레이아웃 및 View, 엘리먼트들을 가로 혹은 세로 한 방향으로 정렬하기 위한 요소 입니다.

####예제
```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout
    xmlns:android="http://schemas.android.com/apk/res/android"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    
    <!-- 자식 View 를 가로로 정렬 하는 LinearLayout Start -->
    <LinearLayout
        android:orientation="horizontal"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="1">
        
        <TextView 
            android:text="red"
            android:gravity="center_horizontal"
            android:background="#aa0000"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1" />
        <TextView
            android:text="green"
            android:gravity="center_horizontal"
            android:background="#00aa00"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layot_weight="1" />
        <TextView
            android:text="blue"
            android:gravity="center_horizontal"
            android:background="#0000aa"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1" />
        <TextView
            android:text="yellow"
            android:gravity="center_horizontal"
            android:background="#aaaa00"
            android:layout_width="wrap_content"
            android:layout_height="match_parent"
            android:layout_weight="1" />
    </LinearLayout>
    <!-- 자식 View 를 가로로 정렬 하는 LinearLayout End -->
    
    <!-- 자식 View 를 세로로 정렬 하는 LinearLayout Start -->
    <LinearLayout
        android:orientation="vertical"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_weight="1">
        <TextView
            android:text="row one"
            android:textSize="15pt"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:layout_weight="1" />
        <TextView
            android:text="row two"
            android:textSize="15pt"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:layout_weight="1" />
        <TextView
            android:text="row three"
            android:textSize="15pt"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:layout_weight="1" />
        <TextView
            android:text="row four"
            android:textSize="15pt"
            android:layout_width="match_parent"
            android:layout_height="wrap_content"
            android:layout_weight="1" />
    </LinearLayout>
    <!-- 자식 View 를 세로로 정렬 하는 LinearLayout End -->
    
</LinearLayout>
```

하위 LinearLayout 들을 세로로 정렬하는 최상위 LinearLayout 이 있습니다. <br />
그 하위 첫번째 LinearLayout 은 하위 View 를 
가로로 정렬하고, 두번째 LinearLayout 은 하위 View를 세로로 정렬하고 있습니다.

####결과
![그림](http://i.imgur.com/Sh0NkpE.png)

결과 화면입니다. 

####참조
- https://developer.xamarin.com/guides/android/user_interface/linear_layout/
- https://developer.xamarin.com/api/type/Android.Widget.LinearLayout/

####예제소스

- https://github.com/NJHouse/TILW/tree/develop/Xamarin/Android/Sample/XAndDemo