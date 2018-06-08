#pragma once

namespace sjtu {
    template <class Type>
    void swap(Type &a, Type &b) {
        Type t(a); a = b; b = t;
    }

    class string {
    private:
        char _str[61];
        int _length;

    public:
        friend class Interactor;
        string(const char *str = "") {
            _length = strlen(_str);
            for (int i = 0; i < _length; ++i)
                _str[i] = str[i];
            _str[_length] = '\0';
        }

        string(const string &oth) {
            _length = oth._length;
            for (int i = 0; i < _length; ++i)
                _str[i] = oth._str[i];
            _str[_length] = '\0';
        }

        string &operator = (const string &oth) {
            if (this == &oth) return *this;
            _length = oth._length;
            for (int i = 0; i < _length; ++i)
                _str[i] = oth._str[i];
            _str[_length] = '\0';
            return *this;
        }

        bool operator < (const string &oth) const {
            for (int i = 0; i < _length && i < oth._length; ++i) {
                if (_str[i] < oth._str[i]) return true;
                if (_str[i] > oth._str[i]) return false;
            }
            return _length < oth._length;
        }

        bool operator > (const string &oth) const {
            return oth < *this;
        }

        bool operator == (const string &oth) const {
            if (_length != oth._length) return false;
            for (int i = 0; i < _length; ++i)
                if (_str[i] != oth._str[i]) return false;
            return true;
        }

        const int length() const {
            return _length;
        }

        const char *c_str() const {
            return _str;
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
    const char *ToString() const {
        static char res[15];
        sprintf(res, "%02d:%02d", hour, minute);
        return res;
    }
    time& operator +=(int x)
    {
        hour = hour + x;
        return *this;
    }
    time& operator -=(int x)
    {
        hour = hour - x;
        return *this;
    }
    time operator +(int x)
    {
        return time(hour + x, minute);
    }
    time operator -(int x)
    {
        return time(hour - x, minute);
    }
};
class date
{
public:
    int year;
    int month;
    int day;
    string catalog;
    date():year(), month(), day(), catalog(){}
    date(int a, int b, int c, const char* d): year(a), month(b), day(c), catalog(d) {}
    date(int a, int b, int c, string d): year(a), month(b), day(c), catalog(d) {}
    date(const char*s1,const char*s2) : catalog(s2)
	{
    	int X;
    	sscanf(s1,"%d-%d-%d %d:%d",&year,&month,&day,&X,&X);
	}
    const char *ToString() const {
        static char res[15];
        sprintf(res, "%04d-%02d-%02d", year, month, day);
        return res;
    }
    bool operator < (const date o)const
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
    bool operator =(const date& o)
    {
        if(year == o.year && month == o.month && day == o.day && catalog == o.catalog) return true;
        return false;
    }
    bool operator ==(const date& o)const
    {
        if(year == o.year && month == o.month && day == o.day && catalog == o.catalog) return true;
        return false;
    }
};
}
