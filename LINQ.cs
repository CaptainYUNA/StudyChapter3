using System;
using System.Collections.Generic;
using System.Text;

namespace StudyChapter3.Collection
{
    public class LINQ
    {
        public void PracticalLINQ()
        {
            var list = new List<string>
            {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong"
            };

            //Exists (시퀀셜), T/F 반환
            //list의 요소 하나하나를 x라는 익명으로 처리
            var exists = list.Exists(x => x[0] == 'A');
            Console.WriteLine(exists);

            exists = list.Exists(x => x.Length > 5);
            Console.WriteLine(exists);

            //Find (시퀀셜), 찾은 것의 타입을 반환
            var find = list.Find(x => x == "Berlin");
            Console.WriteLine(find);

            //FindIndex (시퀀셜), int 반환
            var index = list.FindIndex(x => x == "Paris");
            Console.WriteLine(index);

            //FindAll (시퀀셜), collection 반환
            var all = list.FindAll(x => x.Length <= 5);
            foreach (var item in all)
            {
                Console.WriteLine(item);
            }

            //RemoveAll (시퀀셜), int 반환 (삭제한 요소의 개수)
            var remove = list.RemoveAll(x => x.Contains("on"));
            Console.WriteLine(remove);

            //ForEach (시퀀셜)
            //--> 인수로 지정한 처리 내용을 각각의 요소를 대상으로 실행 (Action<T> 델리게이트를 인수로 받음)
            list.ForEach(x => Console.WriteLine(x)); // 반환 값이 없으므로 (실행만 하므로) 변수 선언 X, 그냥 foreach 쓰는 것과 동일함

            //ConvertAll
            var lowerList = list.ConvertAll(x => x.ToLower());
            foreach (var item in lowerList)
            {
                Console.WriteLine(itemr);
            }
        }
    }
}
