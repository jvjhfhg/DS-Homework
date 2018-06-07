#pragma once

namespace sjtu {
    template <class Type>
    void swap(Type &a, Type &b) {
        Type t(a); a = b; b = t;
    }


class string{
public:
	char ch[61];
	int length;
	string() = default;
	string(const char*s){
		const char*ss;
		ss=s;
		while(*ss)ss++;
		length=ss-s;
		for(int i=0;s+i<=ss;i++)
			ch[i]=s[i];
	}
    string(const string&z){
        const char*ss=z.ch;
        while(*ss)ss++;
        length=ss-z.ch ;
        for(int i=0;z.ch+i<=ss;i++)
            ch[i]=z.ch[i];
	}
    string& operator=(const string&z){
		const char*ss=z.ch;
		while(*ss)ss++;
		length=ss-z.ch;
		for(int i=0;z.ch+i<=ss;i++)
			ch[i]=z.ch[i];
		return *this;
	}

	bool operator<(string w){
		char*oo=w.ch;
		for(int i=0;;i++){
			if(ch[i]==0||oo[i]==0)return oo[i]!=0;
			if(ch[i]!=oo[i])return ch[i]<oo[i];
		}
	}
	bool operator>(string w){
		char*oo=w.ch;
		for(int i=0;;i++){
			if(ch[i]==0||oo[i]==0)return oo[i]!=0;
			if(ch[i]!=oo[i])return ch[i]>oo[i];
		}
	}
	bool operator==(string w){
		char*oo=w.ch;
		for(int i=0;;i++){
			if(ch[i]==0||oo[i]==0)return ch[i]==0&&oo[i]==0;
			if(ch[i]!=oo[i])return 0;
		}
	}

};

class time
{
public:
    int hour;
    int minute;
    time(int a = 0, int b = 0): hour(a), minute(b) {}
    time(const char*s)
	{
    	int X;
    	sscanf(s,"%d-%d-%d %d:%d",&X,&X,&X,&hour,&minute);
	}
	bool operator <(time o)
    {
        if(hour < o.hour) return true;
        if(hour > o.hour) return false;
        if(minute < o.minute) return true;
        return false;
    }
};
class date
{
public:
    int year;
    int month;
    int day;
    string catalog;
    date(int a, int b, int c, const char* d): year(a), month(b), day(c), catalog(d) {}
    date(int a, int b, int c, string d): year(a), month(b), day(c), catalog(d) {}
    date(const char*s1,const char*s2) : catalog(s2)
	{
    	int X;
    	sscanf(s1,"%d-%d-%d %d:%d",&year,&month,&day,&X,&X);
	}
    bool operator < (date o)
    {
        if(year < o.year) return true;
        if(year > o.year) return false;
        if(month < o.month) return true;
        if(month > o.month) return false;
        if(day < o.day) return true;
        if(day > o.day) return false;
        if(catalog < o.catalog) return true;
        return false;
    }
};
}
