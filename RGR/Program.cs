using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задать уравнение и его параметры
            // Например, найдем x для уравнения x^2 - 5 = 0
            //Func<double, double> equation = x => Math.Pow(x, 3) - 25 + 3*x;
            //Func<double, double> equation = x => Math.Pow(x, 2) - 5;
            Func<double, double> equation = x => 3*x + 25 - 17 + 2*x - x;
            double target = 0;

            // Инициализация параметров генетического алгоритма
            int populationSize = 100;
            double mutationRate = 0.01;
            double crossoverRate = 0.7;

            // Создание начальной популяции
            List<Chromosome> population = InitializePopulation(populationSize);

            for (int generation = 0; generation < 1000; generation++)
            {
                // Оценить популяцию
                EvaluatePopulation(population, equation, target);

                // Выбрать лучших особей для скрещивания
                List<Chromosome> parents = SelectParents(population, crossoverRate);

                // Скрестить родителей для создания потомства
                List<Chromosome> offspring = Crossover(parents);

                // Мутировать потомство
                Mutate(offspring, mutationRate);

                // Заменить старую популяцию новой
                population = offspring;

                // Вывести информацию о лучшем решении
                Console.WriteLine("Лучшее решение для поколения {0}: {1}", generation, population[0].X);
            }
        }

        // Инициализировать начальную популяцию
        static List<Chromosome> InitializePopulation(int populationSize)
        {
            var population = new List<Chromosome>();

            for (int i = 0; i < populationSize; i++)
            {
                // Создаем случайную хромосому
                var chromosome = new Chromosome();
                chromosome.X = Random.NextDouble() * 10 - 5;
                population.Add(chromosome);
            }

            return population;
        }

        // Оценка популяции
        static void EvaluatePopulation(List<Chromosome> population, Func<double, double> equation, double target)
        {
            foreach (var chromosome in population)
            {
                chromosome.Fitness = Math.Abs(equation(chromosome.X) - target);
            }
        }

        // Выбор лучших особей
        static List<Chromosome> SelectParents(List<Chromosome> population, double crossoverRate)
        {
            population.Sort((a, b) => a.Fitness.CompareTo(b.Fitness));

            var parents = new List<Chromosome>();
            for (int i = 0; i < (int)(population.Count * crossoverRate); i++)
            {
                parents.Add(population[i]);
            }

            return parents;
        }

        // Скрещивание родителей
        static List<Chromosome> Crossover(List<Chromosome> parents)
        {
            var offspring = new List<Chromosome>();

            for (int i = 0; i < parents.Count - 1; i += 2)
            {
                var offspring1 = new Chromosome();
                var offspring2 = new Chromosome();
                offspring1.X = parents[i].X * 0.5 + parents[i + 1].X * 0.5;
                offspring2.X = parents[i + 1].X * 0.5 + parents[i].X * 0.5;

                // Добавить потомство в список
                offspring.Add(offspring1);
                offspring.Add(offspring2);
            }

            return offspring;
        }

        // Мутировать потомство
        static void Mutate(List<Chromosome> offspring, double mutationRate)
        {
            foreach (var off_spring in offspring)
            {
                // Мутация гена
                if (Random.NextDouble() < mutationRate)
                {
                    off_spring.X += Random.NextDouble() * 0.1 - 0.05;
                }
            }
        }

        // Класс хромосомы
        class Chromosome
        {
            public double X { get; set; }
            public double Fitness { get; set; }
        }

        // Генератор случайных чисел
        static Random Random = new Random();
    }
}