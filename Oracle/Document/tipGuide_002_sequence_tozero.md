# Table Sequence Zero 초기화 방법

##1. 시퀀스 증가시켜서 값을 확인한다.
```PLSQL
SELECT camp.seq_oceanworld_coupon.NEXTVAL FROM DUAL;
```

##2. 그 값으로 마이너스 하도록 수정한다.
```PLSQL
ALTER SEQUENCE camp.seq_oceanworld_coupon INCREMENT BY -5 MINVALUE 0;
```  

##3. 시퀀스 증가시켜서 값을 확인한다. (0이 되어 있음)
```PLSQL
SELECT camp.seq_oceanworld_coupon.NEXTVAL FROM DUAL;
```

##4. 다시 1씩 증가 하도록 설정한다 (1부터 시작함)
```PLSQL
ALTER SEQUENCE camp.seq_oceanworld_coupon INCREMENT BY 1 MINVALUE 0;
```