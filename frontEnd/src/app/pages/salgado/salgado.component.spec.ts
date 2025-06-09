import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SalgadoComponent } from './salgado.component';
import { HttpClientTestingModule } from '@angular/common/http/testing'; // Para testes HTTP
import { ReactiveFormsModule } from '@angular/forms';

describe('SalgadoComponent', () => {
  let component: SalgadoComponent;
  let fixture: ComponentFixture<SalgadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalgadoComponent, HttpClientTestingModule, ReactiveFormsModule], // Adicionando módulos necessários
    }).compileComponents();

    fixture = TestBed.createComponent(SalgadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
