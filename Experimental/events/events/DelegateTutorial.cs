using System;

public class DelegateTutorial
{
    int num = 0;

    delegate void DelegateExample(int a);

	public DelegateTutorial()
	{
        DelegateExample myDelegate = Bar;
        myDelegate(6);

        //Foo(myDelegate);
        Foo(Bar);
	}

    void Foo(DelegateExample myDelegate) {

    }

    void Bar(int a)
    {
        num += a;
    }
}
