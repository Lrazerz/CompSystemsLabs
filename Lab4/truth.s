.include "defs.h"
.section .bss
envp: .quad 0
.section .text
.global _start
newline: .byte '\n'

_start:
    movq (%rsp), %rbx /* rbx = argc (value) */
    movq %rsp, %rcx /* rcx = *argc */
    addq $1, %rbx /* rbx = argc + 1 */
    movq $8, %rax /* rax = 8 (in order to multiply) */
    mulq %rbx /* rax = rax * rbx  [ rax = 8 * (argc + 1) ] */
    addq %rax, %rcx /* rcx = rcx + rax  [ rcx = *(rsp + 8 * (argc + 1)) ] [rcx contains pointer to Envp-8] */
    movq %rcx, envp /* envp = *(Envp-8) */
extcycle: /* external cycle */
    addq $8, envp /* envp = *Envp[x] */
    movq envp, %r9 /* to compare value of Envp[x] */
    cmpq $0, (%r9) /* while (Envp[x] != NULL) */
    je end
    movq envp, %rcx /* rcx = *(Envp) */
    movq (%rcx), %rsi /* rsi = Envp[x] [rsi - reg to output] */
    movq %rsi, %rdi /* rdi = Envp[x] */
    movq $0, %rdx /* rdx = 0 [ rdx = count of symbols to write ] */

intcycle: /* internal cycle */
	cmpb $0, (%rdi) /* while *p != '\0' */
	je extcyclecnt
	incq %rdi  /* p++ */
	incq %rdx  /* len++ */
	jmp intcycle

extcyclecnt:
    movq $SYS_WRITE, %rax 
    movq $STDOUT, %rdi
    syscall /* write Envp[x] */
    movq $SYS_WRITE, %rax 
    movq $STDOUT, %rdi
    movq $1, %rdx
    movq $newline, %rsi
    syscall /*write newLine */
    jmp extcycle

end: /* exit */
    movq $SYS_EXIT, %rax
    movq $0, %rdi
    syscall

as -o asd.o -c asd.s
ld -static -o asd asd.o