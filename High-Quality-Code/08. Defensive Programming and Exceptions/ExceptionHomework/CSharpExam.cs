﻿using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentException("Score must be a positive number.");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < 0 || Score > 100)
        {
            throw new ArgumentException("Score must be between 0 and 100.");
        }
        else
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}