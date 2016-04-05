# Table Sequence 재설정 방법

가끔 Sequence 값이 테이블 데이타의 Sequence 값과 달라 중복 오류를 뱉어내곤 한다.
이럴땐 Sequence 값을 재설정 해줘야 하는데 아래는 그 방법을 서술했다.

## 1. 현재 Sequence 값을 확인한다.
```PLSQL
SELECT wacam.seq_ss_dictionary.currval FROM DUAL;
```

## 2. 현재 Sequence 보다 1작은 수 만큼 뺀 후 Sequence 1로 만든다.
```PLSQL
ALTER SEQUENCE wacam.seq_ss_dictionary INCREMENT BY -2359;
SELECT wacam.seq_ss_dictionary.nextval FROM DUAL;
```

## 3. 테이블에 입력되어 있는 Sequence 만큼 증가 시키고 Sequence 를 증가 시킨다.
```PLSQL
ALTER SEQUENCE wacam.seq_ss_dictionary INCREMENT BY 2400;
SELECT wacam.seq_ss_dictionary.nextval FROM DUAL;
```

## 4. Sequence 를 1씩 증가시키기 위한 마지막 작업을 한다.
```PLSQL
ALTER SEQUENCE wacam.seq_ss_dictionary INCREMENT BY 1;
``` 
