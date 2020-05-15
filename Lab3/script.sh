#!/bin/bash

_basePath="/home/grid/testbed/tb159/newLab3/autoVectProg/"

cd $_basePath

flagsForOptimization=(O0 O1 O2 O3 Os Ofast)

i=0

for flag in ${flagsForCmplrOptmztion[@]}

do

        echo "g++ compilation using flag $flag:"

        srcfile="result$i"

        g++ -$flag program.cpp -o $srcfile -lm

        time ./$srcfile

        let "i=i+1"

        echo -e "\n"

done

ml icc                                                                           

flagsForCpu=$(cat /proc/cpuinfo | grep flags | cut -d: -f2 | uniq)

flagsForOptimization=(O2 Ofast)

i=0

for optmzFlag in ${flagsForOptimization[@]}

do

        for iccFlag in $flagsForCpu

        do

                srcfile="iccResult$iccFlag$optmzFlag"

                icc -$optmzFlag -qopt-report-phase=vec program.cpp -o $srcfile -lm -x$iccFlag 2> errors.txt

                if [ $? -eq 0 ]

                then

                        echo "icc compilation with -$optmzFlag flag and $iccFlag cpu extension:"

                        time ./$srcfile

                        echo -e "\n"

                fi

        done

done