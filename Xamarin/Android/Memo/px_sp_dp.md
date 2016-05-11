- 안드로이드 레이아웃 사이즈 단위 : px, in, mm, pt, dp, sp...
- 주로 dp, sp, px 를 사용한다
- px 는 픽셀을 나타냅니다.
    - 변환식 : px = dp x (dpi/160)
- dp(dip) 
    - Density-independent Pixel
    - 안드로이드에서 사용하는 독립적 단위 수치
    - 1dp 는 160dpi 화면에서 1px 에 대응
    - dp = px * ratio (비율)
- sp
    - Scale-independent Pixel 
    - 사용자의 폰트 선호도에 따라 크기가 달라짐
    - 주로 폰트 사이즈 설정에 사용
    - sp = dp * scale
    
1dp 값

|DPI|LDPI(120dpi)|MDPI(160dpi)|HDPI(240dpi)|XHDPI(320dpi)|XXHDPI(480dpi)|XXXHDPI(640dpi)
| :---: | :---: | :---: | :---: | :---: | :---: | :---:
| px|0.75px|1px|1.5px|2px|3px|4px

- dpi 개념
    - 인치당 도트를 가진 단위를 말한다
    - 120 dpi 는 1인치 안에 도트가 120개 들어간다는 말

###참고
- http://leipiel.tistory.com/7

###정리

1. 인사말
2. 개요
3. px 정의
4. dp(dip) 정의
5. sp 정의
6. 변환식
